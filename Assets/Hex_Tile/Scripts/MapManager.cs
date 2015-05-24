using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
//
//[System.Serializable]
//public class MapData:ScriptableObject{
//	
//	public int ID;
//	public string Name;
//	public string Author;
//	public string Version;
//	public List<Vector2> GridsPos=new List<Vector2>();
//	public List<int> GridsHeight=new List<int>();
//	public List<int> GridsLand = new List<int> ();
//
//}

public class MapManager{

	public static MapData MapToObject(HexMap Map)
	{
		MapData MMTemp = ScriptableObject.CreateInstance<MapData>();
		MMTemp.ID = Map.ID;
		MMTemp.Name = Map.Name;
		MMTemp.Author = Map.Author;
		MMTemp.Version = Map.Version;
		foreach (Vector2 pos in Map.GetAllGrids().Keys) 
		{
			MMTemp.GridsPos.Add (pos);
			MMTemp.GridsHeight.Add (Map.GetAllGrids()[pos].Height);
			MMTemp.GridsLand.Add (Map.GetAllGrids ()[pos].Land);
		}
		return MMTemp;
	}

	public static HexMap ObjectToMap(MapData MMData)
	{
		HexMap Map = new HexMap ();
		Map.ID = MMData.ID;
		Map.Name = MMData.Name;
		Map.Author = MMData.Author;
		Map.Version = MMData.Version;
		for (int i=0; i<MMData.GridsPos.Count; i++) {
			Map.AppendGrid (MMData.GridsPos[i],new HexGrids(MMData.GridsHeight[i],MMData.GridsLand[i]));
		}
		return Map;
	}

	public static HexMap JsonToMap(JsonData MapData)
	{
		HexMap Map = JsonMapper.ToObject<HexMap> (MapData ["Info"].ToJson());
		for(int i=0;i<MapData["Grid"].Count;i++)
		{
			JsonData GridData=MapData["Grid"][i];
			HexGrids GridTemp=new HexGrids(int.Parse (GridData["Height"].ToString()),int.Parse (GridData["Land"].ToString ()));
			Map.AppendGrid (new Vector2 (int.Parse (GridData["x"].ToString ()),int.Parse (GridData["y"].ToString ())),GridTemp);
		}
		Debug.Log ("Translating Json To Map");
		return Map;
	}

	public static JsonData MapToJson(HexMap Map)
	{
		JsonData Data=new JsonData();
		JsonData InfoData=JsonMapper.ToObject (JsonMapper.ToJson(Map));
		JsonData GridData = new JsonData ();
		foreach(Vector2 GridPos in Map.GetAllGrids().Keys)
		{
			JsonData AGridData=new JsonData();
			AGridData ["x"]=GridPos.x;
			AGridData ["y"]=GridPos.y;
			AGridData ["Height"]=Map.GetAllGrids()[GridPos].Height;
			AGridData ["Land"]=Map.GetAllGrids ()[GridPos].Land;
			GridData.Add(AGridData);
		}
		Data ["Info"] = InfoData;
		Data ["Grid"] = GridData;
		Debug.Log ("Tanslating Map To Json");
		return Data;
	}

}
