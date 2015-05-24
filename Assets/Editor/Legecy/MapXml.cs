//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Xml;
//
//public class MapXml:ScriptableObject
//{
//	#if UNITY_STANDALONE
//	static string mapPath=Application.dataPath;
//	#else
//	static string mapPath = Application.persistentDataPath;
//	#endif 
//
//	public static void SaveMap(HexMap Map)
//	{
//		string Path=mapPath +"/"+Map.Name+@".xml";
//		if (CompareVersion (Map)) 
//		{
//			XmlDocument mapDoc = new XmlDocument();
//			XmlElement root=mapDoc.CreateElement("map");
//			XmlElement id=mapDoc.CreateElement("id");
//			XmlElement name=mapDoc.CreateElement ("name");
//			XmlElement author=mapDoc.CreateElement ("author");
//			XmlElement version=mapDoc.CreateElement ("version");
//			XmlElement grids=mapDoc.CreateElement ("grids");
//			id.InnerText=Map.ID.ToString ();
//			name.InnerText=Map.Name;
//			author.InnerText=Map.Author;
//			version.InnerText=Map.Version;
//			int i=1;
//			foreach(HexGrids g in Map.GetAllGrids().Values)
//			{
//				XmlElement temp=mapDoc.CreateElement("g"+i);
//				temp.InnerText=g.Land.ToString ();
//				temp.SetAttribute("h",g.Height.ToString());
//				grids.AppendChild(temp);
//				i++;
//			}
//			root.AppendChild(id);
//			root.AppendChild(name);
//			root.AppendChild(author);
//			root.AppendChild (version);
//			root.AppendChild (grids);
//			mapDoc.AppendChild (root);
//			mapDoc.Save (Path);
//			Debug.Log(Path);
//			Debug.Log ("Save Map "+Map.Name+" Finish!");
//		}
//	}
//
//	public static HexMap LoadMap(string MapName)
//	{		
//		string Path=mapPath +"/"+MapName+@".xml";
//		HexMap TempMap =new HexMap();
//		if(File.Exists(Path))
//		{
//			XmlDocument mapDoc=new XmlDocument();
//			mapDoc.Load (Path);
//			XmlNode root=mapDoc.SelectSingleNode("map");
//			XmlNode id=root.SelectSingleNode("id");
//			XmlNode name=root.SelectSingleNode("name");
//			XmlNode author=root.SelectSingleNode("author");
//			XmlNode version=root.SelectSingleNode ("version");
//			XmlNode grids=root.SelectSingleNode ("grids");
//			TempMap.ID=int.Parse (id.InnerText);
//			TempMap.Name=name.InnerText;
//			TempMap.Author=author.InnerText;
//			TempMap.Version=version.InnerText;
//			LandXml.LoadLandFile();
//			foreach(XmlElement gn in grids.ChildNodes)
//			{
//				HexGrids TempGrid=new HexGrids(int.Parse (gn.GetAttribute("h")));
//				TempGrid.Land=int.Parse (gn.InnerText);
//				TempMap.AppendGrid(new Vector2(int.Parse (gn.GetAttribute("x")),int.Parse (gn.GetAttribute("y"))),TempGrid);
//			}
//		}
//		else
//		{
//			Debug.Log ("File Not Exists");
//			return null;
//		}
//		return TempMap;
//	}
//	public static HexMap InitMap(int id,string name,int r)
//	{
//				HexMap Map = new HexMap();
//				List<Vector2> GridPos = Map.Area (Vector2.zero, r);
//				foreach (Vector2 pos in GridPos) {
//						HexGrids gTemp = new HexGrids (1);
//						Map.AppendGrid (pos, gTemp);
//				}
//				Map.ID = id;
//				Map.Author = "Nameless";
//				Map.Name = name;
//				Map.Version = "0.0.1";
//				MapXml.SaveMap (Map);
//		return Map;
//	}
//
//	public static bool CompareVersion(HexMap HMap)
//	{
//		//if exists New Version
//		return true;
//	}
//}
