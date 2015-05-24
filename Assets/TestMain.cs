using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class TestMain : MonoBehaviour {

	public HexMap Map;
	public MapData MData;
	public int TestStatus=1;
	static string ObjectPath="Assets/Data/";
	static string ABPath="Assets/AssetBundle/";
	 
	void Start(){
//		Map = MapManager.JsonToMap (DescManager.DescTOJson ("TestMap"));
//		if(Map!=null)
//		GridControl.Status = TestStatus;
//		TestClass to = ScriptableObject.CreateInstance<TestClass> ();
//		AssetDatabase.CreateAsset(to,ObjectPath+"TO.asset");
//		AllLandFormData ALFData= (AllLandFormData)AssetDatabase.LoadAssetAtPath(ObjectPath + "LandForm.asset",typeof(AllLandFormData));
//		AllLandEffectData  ALEData= (AllLandEffectData)AssetDatabase.LoadAssetAtPath(ObjectPath + "LandEffect.asset",typeof(AllLandEffectData));
//		LandManager.LoadLandObject (ALFData, ALEData);
		//StartCoroutine (Test ("SORes", "TestMap.asset"));
		Map = MapManager.ObjectToMap (MData);
		Map.Draw ();
	}
		
	IEnumerator Test(string assetBundleName,string assetName)
	{		
		WWW download = null;
		string url = ABPath + assetBundleName;

		// Load asset from assetBundle.
		AssetBundleLoadAssetOperation request = AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(MapData) );
		if (request == null)
			yield break;
		yield return StartCoroutine(request);
		
		// Get the asset.
		MData = request.GetAsset<MapData> ();
		yield break;
	}
}

