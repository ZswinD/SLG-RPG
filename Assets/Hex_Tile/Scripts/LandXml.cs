using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class LandXml:ScriptableObject
{
	#if UNITY_STANDALONE
	static string landPath=Application.dataPath+@"/land.xml";
	#else
	static string landPath = Application.persistentDataPath+@"/land.xml;
	#endif
	
	public static Dictionary<int,LandForm> LandFormDict=new Dictionary<int,LandForm>();
	public static Dictionary<int,LandEffect> LandEffectDict=new Dictionary<int,LandEffect>();

	public static void initLandFile()
	{
		if(!File.Exists(landPath))
		{
			/*
			XmlDocument landDoc=new XmlDocument();
			XmlElement root=landDoc.CreateElement("land");
			XmlElement landform=landDoc.CreateElement("landform");
			XmlElement landeffect=landDoc.CreateElement ("landeffect");
			XmlElement defaultLand=landDoc.CreateElement("default");
			defaultLand.SetAttribute ("noe","0");
			defaultLand.SetAttribute ("id","0");
			defaultLand.InnerText="0,1;";
			landform.AppendChild (defaultLand);
			XmlElement defaultEffect=landDoc.CreateElement ("null");
			defaultEffect.SetAttribute ("id","0");
			defaultEffect.SetAttribute ("key","null");
			defaultEffect.InnerText="TestEffect";
			landeffect.AppendChild (defaultEffect);
			root.AppendChild(landform);
			root.AppendChild(landeffect);
			landDoc.AppendChild (root);
			landDoc.Save(landPath);
			*/
			LandEffect nullEffect=new LandEffect(0,"null","null","TestEffect");
			LandEffectDict.Add(0,nullEffect);
			LandForm defaultForm=new LandForm();
			defaultForm.ID=0;
			defaultForm.Name="default";
			defaultForm.Effect=new Dictionary<int,float>();
			defaultForm.Effect.Add (0,1);
			LandFormDict.Add(0,defaultForm);
			Debug.Log ("Start to save landfile");
			SaveLandFile(LandFormDict,LandEffectDict);
		}
		else
			Debug.Log("Already init Landfile!");
	}

	public static void LoadLandFile()
	{
		Dictionary<int,LandForm> LandFormList = new Dictionary<int,LandForm>();
		if(File.Exists(landPath))
		{
			Debug.Log ("Loading LandFile");
			XmlDocument landDoc=new XmlDocument();
			landDoc.Load (landPath);
			XmlNode root=landDoc.SelectSingleNode ("land");
			XmlNode landform=root.SelectSingleNode("landform");
			foreach(XmlElement lfEle in landform.ChildNodes)
			{
				LandForm landformTemp=ScriptableObject.CreateInstance<LandForm>();
				landformTemp.ID=int.Parse (lfEle.GetAttribute ("id"));
				landformTemp.Name=lfEle.Name;
				landformTemp.Effect=new Dictionary<int,float>();
				string[] strLandEffects=lfEle.GetAttribute("eff").Split(';');
				foreach(string strLand in strLandEffects)
				{
					if(strLand.Length==0||strLand[0]==' ')
						continue;
					string[] strArgs=strLand.Split (',');
					landformTemp.Effect.Add(int.Parse(strArgs[0]),float.Parse (strArgs[1]));
					LandFormList.Add (landformTemp.ID,landformTemp);
				}
			}
			LandFormDict=LandFormList;
		}
		else
		{
			Debug.Log ("no LandFile");
			initLandFile();
			LoadLandFile ();
		}
	}

	public static void LoadLandEffect()
	{
		Dictionary<int,LandEffect> LandEffectList = new Dictionary<int,LandEffect>();
		if(File.Exists(landPath))
		{
			XmlDocument landDoc=new XmlDocument();
			landDoc.Load (landPath);
			XmlNode root=landDoc.SelectSingleNode ("land");
			XmlNode landeffect=root.SelectSingleNode("landeffect");
			foreach(XmlElement leEle in landeffect.ChildNodes)
			{
				LandEffect landeffectTemp=new LandEffect();
				landeffectTemp.ID=int.Parse(leEle.GetAttribute ("id"));
				landeffectTemp.Key=leEle.GetAttribute ("key");
				landeffectTemp.Name=leEle.Name;
				landeffectTemp.Desc=leEle.GetAttribute ("desc");
				LandEffectList.Add(landeffectTemp.ID,landeffectTemp);
			}
			LandEffectDict=LandEffectList;
		}
		else
		{
			initLandFile();
			LoadLandEffect();
		}
	}

	public static void SaveLandFile(Dictionary<int,LandForm> LandFormList,Dictionary<int,LandEffect> LandEffectList)
	{
		if(!File.Exists(landPath))
		{
			XmlDocument landDoc=new XmlDocument();
			XmlElement root=landDoc.CreateElement("land");
			XmlElement landform=landDoc.CreateElement("landform");
			XmlElement landeffect=landDoc.CreateElement ("landeffect");
			foreach(LandForm LF in LandFormList.Values)
			{
				XmlElement LFXE=landDoc.CreateElement(LF.Name);
				LFXE.SetAttribute ("id",LF.ID.ToString());
				string strLandEffect="";
				foreach(int LEID in LF.Effect.Keys)
				{
					strLandEffect+=(LEID+","+LF.Effect[LEID]+";");
				}
				LFXE.SetAttribute ("eff",strLandEffect);
				landform.AppendChild (LFXE);
			}
			foreach(LandEffect LE in LandEffectList.Values)
			{
				XmlElement LEXE=landDoc.CreateElement (LE.Name);
				LEXE.SetAttribute ("id",LE.ID.ToString ());
				LEXE.SetAttribute ("key",LE.Key.ToString ());
				LEXE.SetAttribute ("desc",LE.Desc.ToString ());
				landeffect.AppendChild (LEXE);
			}
			root.AppendChild(landform);
			root.AppendChild(landeffect);
			landDoc.AppendChild (root);
			landDoc.Save(landPath);
			Debug.Log ("save Landfile Finish!");
		}
	}

	public static void ChangeLandEffect(LandEffect LE,bool IsChange)
	{
		LoadLandEffect();
		
	}
}
