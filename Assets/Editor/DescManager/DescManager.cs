using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;

public class DescManager
{
	static DescManager Manager;

	static string ManagerPath;
	static string Path = Application.dataPath + "/Editor/Desc/";
	static string ControlFileName="Control";
	static string ObjectPath="Assets/Data/";
	static string ABPath="Assets/AssetBundle/";
	public static JsonData ControlData;
	
	public static void DescToObject(string descName,string descClass,string objectName)
	{
		JsonData DescData = DescTOJson (descName);
		ScriptableObject sObject =ScriptableObject.CreateInstance<ScriptableObject>();
		string finPath = ObjectPath + objectName+@".asset";
		switch (descClass) 
		{
		case("Map"):
			sObject=ScriptableObject.CreateInstance<MapData>();
			HexMap Map=MapManager.JsonToMap(DescData);
			sObject =MapManager.MapToObject (Map);
			AssetDatabase.CreateAsset(sObject,finPath);
			break;
		case("LandForm"):
			sObject=ScriptableObject.CreateInstance<AllLandFormData>();
			Dictionary<int,LandForm> LFDict=LandManager.LoadLandForm (DescData);
			sObject =LandManager.DataToLFObject(LFDict);
			AssetDatabase.CreateAsset(sObject,finPath);
			break;
		case("LandEffect"):
			sObject=ScriptableObject.CreateInstance<AllLandEffectData>();
			Dictionary<int,LandEffect> LEDict=LandManager.LoadLandEffect (DescData);
			sObject =LandManager.DataToLEObject(LEDict);
			AssetDatabase.CreateAsset(sObject,finPath);
			break;
		}
		Debug.Log ("Finish Output "+objectName );
	}

	public static void AllDescToObject()
	{
		ControlData = DescTOJson (ControlFileName);
		for(int i=0;i<ControlData.Count;i++)
		{
			JsonData DescData=ControlData[i];
			DescToObject(DescData["descName"].ToString (),DescData["descClass"].ToString (),DescData["objectName"].ToString ());
		}
		AssetDatabase.SaveAssets ();
		Debug.Log ("Finish All Desc Translate!");
	}

	public static void OutputControlFile()
	{
		JsonToDesc (ControlFileName,ControlData);
		Debug.Log ("Finish Output Control File");
	}
	public static void OutputControlFile(JsonData data)
	{
		JsonToDesc (ControlFileName, data);
		Debug.Log ("Finish Output Control File");
	}

	public static JsonData DescTOJson(string DescPath)
	{
		string PathTemp = Path+DescPath+@".desc";
		JsonData data=new JsonData();
		Debug.Log ("Reading "+PathTemp);
		if (File.Exists(PathTemp)) {
			string jsonStr=File.ReadAllText(PathTemp);
			data=JsonMapper.ToObject (jsonStr);
			Debug.Log ("Writing Json");
		} 
		else
		{
			Debug.Log ("No such Desc");
			File.WriteAllText (PathTemp,"AAAAAA");
		}
		return data;
	}
	
	public static void JsonToDesc(string DescPath,JsonData data)
	{
		string PathTemp=Path+DescPath+@".desc";
		string jsonStr=JsonMapper.ToJson (data);
		Debug.Log ("Writing " + PathTemp);
		File.WriteAllText (PathTemp, jsonStr);
	}

	public static void OutputAssetBundle()
	{
		ControlData = DescTOJson (ControlFileName);
		AssetBundleBuild[] BuildMap=new AssetBundleBuild[1];
		BuildMap[0].assetBundleName="SORes";
		List<string> ResourceAssets = new List<string> ();
		for(int i=0;i<ControlData.Count;i++)
		{
			Debug.Log (ObjectPath+ControlData[i]["objectName"]);
			ResourceAssets.Add (ObjectPath+ControlData[i]["objectName"]+".asset");
		}
		BuildMap [0].assetNames = ResourceAssets.ToArray ();
		BuildPipeline.BuildAssetBundles (ABPath, BuildMap);
		Debug.Log ("Scriptable Object Packer Finish");
	}
}
