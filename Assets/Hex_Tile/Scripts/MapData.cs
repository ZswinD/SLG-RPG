using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

[System.Serializable]
public class MapData:ScriptableObject{
	
	public int ID;
	public string Name;
	public string Author;
	public string Version;
	public List<Vector2> GridsPos=new List<Vector2>();
	public List<int> GridsHeight=new List<int>();
	public List<int> GridsLand = new List<int> ();
	
}