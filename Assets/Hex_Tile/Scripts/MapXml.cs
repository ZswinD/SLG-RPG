using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class MapXml:ScriptableObject
{
	#if UNITY_STANDALONE
	static string mapPath=Application.dataPath;
	#else
	static string mapPath = Application.persistentDataPath;
	#endif 

	public static void SaveMap(HexMap Map)
	{
		string Path=mapPath +"/"+Map.name+@".xml";
		if (CompareVersion (Map)) 
		{
			XmlDocument mapDoc = new XmlDocument();
			XmlElement root=mapDoc.CreateElement("map");
			XmlElement id=mapDoc.CreateElement("id");
			XmlElement name=mapDoc.CreateElement ("name");
			XmlElement author=mapDoc.CreateElement ("author");
			XmlElement version=mapDoc.CreateElement ("version");
			XmlElement grids=mapDoc.CreateElement ("grids");
			id.InnerText=Map.ID.ToString ();
			name.InnerText=Map.Name;
			author.InnerText=Map.Author;
			version.InnerText=Map.Version;
			foreach(HexGrids g in Map.Grids.Values)
			{
				int i=1;
				XmlElement temp=mapDoc.CreateElement("g"+i);
				temp.InnerText=g.Land.ID.ToString ();
				temp.SetAttribute("x",g.Position.x.ToString());
				temp.SetAttribute("y",g.Position.y.ToString());
				temp.SetAttribute("h",g.Height.ToString());
				grids.AppendChild(temp);
				i++;
			}
			root.AppendChild(id);
			root.AppendChild(name);
			root.AppendChild(author);
			root.AppendChild (version);
			root.AppendChild (grids);
			mapDoc.AppendChild (root);
			mapDoc.Save (Path);
			Debug.Log(Path);
			Debug.Log ("Save Map "+Map.Name+" Finish!");
		}
	}

	public static HexMap LoadMap(string MapName)
	{		
		string Path=mapPath +"/"+MapName+@".xml";
		HexMap TempMap =ScriptableObject.CreateInstance<HexMap>();
		if(File.Exists(Path))
		{
			XmlDocument mapDoc=new XmlDocument();
			mapDoc.Load (Path);
			XmlNode root=mapDoc.SelectSingleNode("map");
			XmlNode id=root.SelectSingleNode("id");
			XmlNode name=root.SelectSingleNode("name");
			XmlNode author=root.SelectSingleNode("author");
			XmlNode version=root.SelectSingleNode ("version");
			XmlNode grids=root.SelectSingleNode ("grids");
			TempMap.ID=int.Parse (id.InnerText);
			TempMap.Name=name.InnerText;
			TempMap.Author=author.InnerText;
			TempMap.Version=version.InnerText;
			foreach(XmlElement gn in grids.ChildNodes)
			{
				Vector2 TempPos=new Vector2(float.Parse (gn.GetAttribute ("x")),float.Parse (gn.GetAttribute ("y")));
				HexGrids TempGrid=new HexGrids(TempPos,int.Parse (gn.GetAttribute("h")));
				TempGrid.Land=LandXml.LoadLandFile()[int.Parse (gn.InnerText)];
				TempMap.Grids.Add (TempPos,TempGrid);
			}
		}
		return TempMap;
	}

	public static bool CompareVersion(HexMap HMap)
	{
		//if exists New Version
		return true;
	}
}
