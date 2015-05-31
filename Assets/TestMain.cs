using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class TestMain : MonoBehaviour {

	public HexMap Map;
	public MapData MData;
	public int TestStatus=1;
	static string ObjectPath="Assets/Data/";
	static string AssetBundlePath="/AssetBundle/";
	 
	void Start(){
//		GridControl.Status = TestStatus;
//		TestClass to = ScriptableObject.CreateInstance<TestClass> ();
		//StartCoroutine (Test ("Map", "TestMap.asset"));
		TransManager t = new TransManager ("");
		Dictionary<string,string> s = new Dictionary<string, string> ();
		s.Add ("attacker", "player");
		s.Add ("deffecer", "enemy");
		Debug.Log (t.getTranslate ("attack_info","cn",s));
	}
		
	IEnumerator Test(string assetBundleName,string assetName)
	{	
		WWW mUrl = null;
		Caching.CleanCache ();
		string url = "file:///" + Application.dataPath+AssetBundlePath;
		mUrl=WWW.LoadFromCacheOrDownload (url+"AssetBundle",0);
		yield return mUrl;
		AssetBundle mAB = mUrl.assetBundle;
		AssetBundleManifest mainfest = (AssetBundleManifest)mAB.LoadAsset ("AssetBundleManifest");
		mAB.Unload (false);
		WWW www = WWW.LoadFromCacheOrDownload (url+"sores",0);
		yield return www;
		AssetBundle soab = www.assetBundle;
		MData = soab.LoadAsset (assetName) as MapData;
		Map = MapManager.ObjectToMap (MData);
		Map.Draw ();
		LandEffectData ledata = soab.LoadAsset ("LandEffect.asset") as LandEffectData;
		LandFormData lfdata = soab.LoadAsset ("LandForm.asset")as LandFormData;
		LandManager.LoadLandObject (lfdata, ledata);
	}
}

