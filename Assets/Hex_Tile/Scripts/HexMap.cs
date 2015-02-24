using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class HexMap : ScriptableObject
{
	public Dictionary<Vector2,HexGrids> Grids=new Dictionary<Vector2, HexGrids>();
	public int ID{ get; set;}
	public string Name{ get; set;}
	public string Author{ get; set;}
	public string Version{ get; set;}
	public double Radius{ get; set;}

	public HexGrids GetGrid(Vector2 Pos)
	{
		if (Grids.ContainsKey (Pos))
						return Grids [Pos];
				else
						return HexGrids.NullGrid;
	}
	public Object GetCell(Vector2 Pos)
	{
		return GetGrid (Pos).Cell;
	}

	public void Draw()
	{
		Debug.Log ("Start Drawing Map" + Name);
		Debug.Log ("Author" + Author);
		Debug.Log ("Version" + Version);
		foreach (HexGrids G in Grids.Values) 
		{
			DrawAGrid (G);
		}
		Debug.Log ("Finish Draw the Map");
	}

	public void DrawAGrid(HexGrids Grid)
	{
		Debug.Log ("Draw A Grid Pos:" + Grid.Position + " Height:" + Grid.Height + " LandForm:" + Grid.Land.Name);
		Radius = 2.74/2.0;
		double sRadius = Radius * Mathf.Sqrt (3) * 0.5;
		Debug.Log ("a=" + Radius + ",b=" + sRadius);
		Vector3 GPos = new Vector3 ((2.0f * Grid.Position.x - Grid.Position.y) * (float)sRadius,Grid.Height*(1.46f), (-1.5f) * Grid.Position.y * (float)Radius);
		Object o = Resources.LoadAssetAtPath("Assets/Hex_Tile/Resource/hexagon.prefab",typeof(GameObject));
		GameObject goAGrid =(GameObject)Instantiate(o);
		GameObject go=GameObject.Find ("Grids");
		goAGrid.transform.parent = go.transform;
		goAGrid.transform.position=GPos;
	}
	Dictionary<string,Vector2> Direction=new Dictionary<string, Vector2>()
	{
		{"TopLeft",new Vector2(0,-1)},
		{"Left",new Vector2(-1,0)},
		{"BotLeft",new Vector2(-1,1)},
		{"BotRight",new Vector2(0,1)},
		{"Right",new Vector2(1,0)},
		{"TopRight",new Vector2(1,-1)}
	};

	public List<HexGrids> Neighbours(Vector2 Center)
	{
		List<HexGrids> TempN =new List<HexGrids>();
		foreach(string s in Direction.Keys){
						TempN.Add (GetGrid (Center+Direction[s]));
				}
		return TempN;
	}

	public HexGrids GetDirection(Vector2 Center,string direct)
	{
		return GetGrid (Center + Direction [direct]);
	}

	//Distance means distance on the map without blocks
	public int CalcDistance(Vector2 Start,Vector2 End)
	{
		return Mathf.FloorToInt ((Mathf.Abs (Start.x - End.x) + Mathf.Abs (Start.y - End.y) + Mathf.Abs (Start.x + Start.y - End.x - End.y)) / 2);
	}

	public List<Vector2> FindPath(Vector2 Start,Vector2 End,Object Cell)
	{
		float f;
		float g;
		float h;
		List<Vector2> Open=new List<Vector2>();
		List<Vector2> Close=new List<Vector2>();
		//A* calc path;
		return Close;
	}

	public void ShowArea(List<HexGrids> Area,int AreaStatus)
	{
		foreach (HexGrids G in Area) {
			ChangeGridObjectStatus (G,AreaStatus);
		}
		Debug.Log ("ShowArea");
	}

	public void ChangeGridObjectStatus(HexGrids Grid,int Status)
	{
		Debug.Log("Change Status of "+Grid.Position+" to "+Status);
	}

	public int NeedSteps(Vector2 start,Vector2 end,Object C)
	{
		if (Grids [end].Height != -1)
						return 1;
		else return -1;
	}

	public Vector2 TouchPointToGridPos(Vector3 worldpos)
	{
		return Vector2.zero;
	}

	public void Move(Vector2 start,Vector2 end,Object cell)
	{
		foreach (Vector2 point in FindPath (start,end,cell)) 
		{
			MoveAGrid(point,point,cell);
		}
	}

	public void MoveAGrid(Vector2 start,Vector2 end,object C)
	{

	}

}
