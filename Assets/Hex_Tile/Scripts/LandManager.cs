using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class LandManager{
	public static Dictionary<int,LandForm> LandFormDict=new Dictionary<int,LandForm>();
	public static Dictionary<int,LandEffect> LandEffectDict=new Dictionary<int,LandEffect>();

	public static LandFormData DataToLFObject (Dictionary<int,LandForm> LandFormDict)
	{
		LandFormData LFData=ScriptableObject.CreateInstance<LandFormData>();
		foreach (int i in LandFormDict.Keys) 
		{
			LFData.ID.Add(i);
			LFData.Name.Add(LandFormDict[i].Name);
			DictionaryOfIntAndFloat doifTemp=new DictionaryOfIntAndFloat();
			foreach(var ele in LandFormDict[i].Effect) {
				doifTemp.Add (ele.Key,ele.Value);
			}
			LFData.Effect.Add (doifTemp);
		}
		return LFData;
	}

	public static LandEffectData DataToLEObject (Dictionary<int,LandEffect> LandEffectDict)
	{
		LandEffectData LEData=ScriptableObject.CreateInstance<LandEffectData>();
		foreach (int i in LandEffectDict.Keys) 
		{
			LEData.ID.Add (i);
			LEData.Name.Add (LandEffectDict[i].Name);
			LEData.Key.Add (LandEffectDict[i].Key);
			LEData.Desc.Add (LandEffectDict[i].Desc);
		}
		return LEData;
	}

	public static Dictionary<int,LandForm> LFObjectToData(LandFormData LFData)
	{
		Dictionary<int,LandForm> LFDictTemp = new Dictionary<int, LandForm> ();
		for (int i=0;i<LFData.ID.Count;i++) 
		{
			LandForm LFTemp=new LandForm();
			LFTemp.ID=LFData.ID[i];
			LFTemp.Name=LFData.Name[i];
			foreach(var ele in LFData.Effect[i])
			{
				LFTemp.Effect.Add (ele.Key,ele.Value);
			}
			LFDictTemp.Add (LFTemp.ID,LFTemp);
		}
		return LFDictTemp;
	}

	public static Dictionary<int,LandEffect> LEObjectToData(LandEffectData LEData)
	{
		Dictionary<int,LandEffect> LEDictTemp = new Dictionary<int, LandEffect> ();
		for (int i=0; i<LEData.ID.Count; i++) 
		{
		    LandEffect ETemp=new LandEffect(LEData.ID[i],LEData.Name[i],LEData.Key[i],LEData.Desc[i]);
			LEDictTemp.Add (ETemp.ID,ETemp);
		}
		return LEDictTemp;
	}

	public static void LoadLandObject(LandFormData LFD, LandEffectData LED)
	{
		LandFormDict = LFObjectToData (LFD);
		LandEffectDict = LEObjectToData (LED);
	}

	public static Dictionary<int,LandForm> LoadLandForm(JsonData LandFormData)
	{
		Dictionary<int,LandForm> DicTemp = new Dictionary<int, LandForm> ();
		for (int i=0; i<LandFormData.Count; i++) 
		{
			LandForm lfTemp=JsonMapper.ToObject <LandForm>(LandFormData[i]["Info"].ToJson());
			for(int j=0;j<LandFormData[i]["Effect"].Count;j++){
			lfTemp.Effect.Add(int.Parse(LandFormData[i]["Effect"][j][0].ToString()),float.Parse (LandFormData[i]["Effect"][j][1].ToString ()));
			}
			DicTemp.Add (lfTemp.ID,lfTemp);
		}
		return DicTemp;
	}

	public static Dictionary<int,LandEffect> LoadLandEffect(JsonData LandEffectData)
	{
		Dictionary<int,LandEffect> DicTemp = new Dictionary<int, LandEffect> ();
		for (int i=0; i<LandEffectData.Count; i++) 
		{
			LandEffect leTemp=JsonMapper.ToObject<LandEffect>(LandEffectData[i].ToJson ());
			DicTemp.Add (leTemp.ID,leTemp);
		}
		return DicTemp;
	}

	public static JsonData LandFormToJson(Dictionary<int,LandForm> LandFormDict)
	{
		JsonData LandFormData= new JsonData();
		for(int i=0;i<LandFormDict.Count;i++)
		{
			JsonData AData=new JsonData();
			AData["Info"]=JsonMapper.ToObject (JsonMapper.ToJson (LandFormDict[i]));
			AData["Effect"]=new JsonData();
			foreach(int j in LandFormDict[i].Effect.Keys)
			{
				JsonData AEffect=new JsonData();
				AEffect.Add (j);
				AEffect.Add ((double)(LandFormDict[i].Effect[j]));
				Debug.Log("ok");
				AData["Effect"].Add(AEffect);
			}
			LandFormData.Add (AData);
		}
		return LandFormData;
	}

	public static JsonData LandEffectToJson(Dictionary<int,LandEffect> LandEffectDict)
	{
		List<LandEffect> AllLE = new List<LandEffect> ();
		foreach(LandEffect lf in LandEffectDict.Values) 
		{
			AllLE.Add(lf);
		}
		JsonData LandEffectData=JsonMapper.ToObject (JsonMapper.ToJson(AllLE));
		return LandEffectData;
	}
}
