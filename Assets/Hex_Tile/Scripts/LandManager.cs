using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class LandManager{
	public static Dictionary<int,LandForm> LandFormDict=new Dictionary<int,LandForm>();
	public static Dictionary<int,LandEffect> LandEffectDict=new Dictionary<int,LandEffect>();

	public static AllLandFormData DataToLFObject (Dictionary<int,LandForm> LandFormDict)
	{
		Debug.Log (LandFormDict.Count);
		LandFormData LFData=ScriptableObject.CreateInstance<LandFormData>();
		AllLandFormData AllLFData=ScriptableObject.CreateInstance<AllLandFormData>();
		foreach (int i in LandFormDict.Keys) 
		{
			LFData.ID=i;
			LFData.Name=LandFormDict[i].Name;
			foreach (int j in LandFormDict[i].Effect.Keys) {
				LFData.EffectID.Add (j);
				LFData.EffectValue.Add(LandFormDict[i].Effect[j]);
			}
			AllLFData.AllLandForm.Add (LFData);
		}
		Debug.Log (AllLFData.AllLandForm.Count);
		return AllLFData;
	}

	public static AllLandEffectData DataToLEObject (Dictionary<int,LandEffect> LandEffectDict)
	{
		LandEffectData LEData=ScriptableObject.CreateInstance<LandEffectData>();
		AllLandEffectData AllLEData=ScriptableObject.CreateInstance<AllLandEffectData>();
		foreach (int i in LandEffectDict.Keys) 
		{
			LEData.ID=i;
			LEData.Effect=LandEffectDict[i];
		}
		AllLEData.AllLandEffect.Add (LEData);
		return AllLEData;
	}

	public static Dictionary<int,LandForm> LFObjectToData(AllLandFormData AllLFData)
	{
		Dictionary<int,LandForm> LFDictTemp = new Dictionary<int, LandForm> ();
		Debug.Log (AllLFData.AllLandForm[0]);
		for (int i=0; i<AllLFData.AllLandForm.Count; i++) 
		{
			LandForm LFTemp=new LandForm();
			LFTemp.ID=AllLFData.AllLandForm[i].ID;
			LFTemp.Name=AllLFData.AllLandForm[i].Name;
			for(int j=0;j<AllLFData.AllLandForm[i].EffectID.Count;j++)
			{
				LFTemp.Effect.Add (AllLFData.AllLandForm[i].EffectID[j],AllLFData.AllLandForm[i].EffectValue[j]);
			}
			LFDictTemp.Add (AllLFData.AllLandForm[i].ID,LFTemp);
		}
		return LFDictTemp;
	}

	public static Dictionary<int,LandEffect> LEObjectToData(AllLandEffectData AllLEData)
	{
		Dictionary<int,LandEffect> LEDictTemp = new Dictionary<int, LandEffect> ();
		for (int i=0; i<AllLEData.AllLandEffect.Count; i++) 
		{
			LEDictTemp.Add (AllLEData.AllLandEffect[i].ID,AllLEData.AllLandEffect[i].Effect);
		}
		return LEDictTemp;
	}

	public static void LoadLandObject(AllLandFormData ALFD, AllLandEffectData ALED)
	{
		LandFormDict = LFObjectToData (ALFD);
		LandEffectDict = LEObjectToData (ALED);
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
