using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class MapXml{
	public string Name{ get; set;}
	public string Author{ get; set;}
	public string Version{ get; set;}
	public int Grade{ get; set;}
	public Dictionary<Vector2,HexGrids> Grids=new Dictionary<Vector2, HexGrids>();

	public Vector2 GridPos{ get; set;}
	public int GridHeight{get;set;}
	public string Land{get;set;}

	public HexMap LoadMap(string MapName)
	{
		string Path = Application.persistentDataPath+"/"+MapName+".xml"	;
		if(File.Exists(Path))
		{
			XmlDocument mapDoc=new XmlDocument();
			mapDoc.Load (Path);
		}
		return new HexMap();
	}
}
