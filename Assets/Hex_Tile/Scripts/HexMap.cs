using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HexMap
{
	Dictionary<Vector2,HexGrids> Grids=new Dictionary<Vector2, HexGrids>();
	public int ID{ get; set;}
	public string Name{ get; set;}
	public string Author{ get; set;}
	public string Version{ get; set;}
	static double Radius= 2.74*0.5;
	static double sRadius = Radius * Mathf.Sqrt (3) * 0.5;

	public void Init(int r)
	{
		List<Vector2> MapArea = Area (Vector2.zero, r);
		for (int i=0; i<MapArea.Count; i++) 
		{
			AppendGrid (MapArea[i],HexGrids.DefaultGrid);
		}
	}

	public bool HasGrid(Vector2 Pos)
	{
		return Grids.ContainsKey (Pos);
	}

	public Dictionary<Vector2,HexGrids> GetAllGrids()
	{
		return Grids;
	}

	public HexGrids GetGrid(Vector2 Pos)
	{
		if (Grids.ContainsKey (Pos))
						return Grids [Pos];
				else
						return null;
	}

	public void AppendGrid(Vector2 Pos,HexGrids AGrid)
	{
		Grids.Add (Pos, AGrid);
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
		foreach (Vector2 gPos in Grids.Keys) 
		{
			DrawAGrid (gPos);
		}
		Debug.Log ("Finish Draw the Map");
	}

	public void DrawAGrid(Vector2 GridPos)
	{
		int height = GetGrid (GridPos).Height;
		Vector3 GPos = new Vector3 ((2.0f * GridPos.x + GridPos.y) * (float)sRadius,height*(1.46f), (-1.5f) * GridPos.y * (float)Radius);
		Object o = Resources.LoadAssetAtPath("Assets/Hex_Tile/Resource/hexagon.prefab",typeof(GameObject));
		GameObject goAGrid =(GameObject)GameObject.Instantiate(o);
		GameObject go=GameObject.Find ("Grids");
		goAGrid.transform.parent = go.transform;
		goAGrid.transform.position=GPos;
		GridControl goControl = goAGrid.GetComponent<GridControl> ();
		goControl.Pos = new Vector2(GridPos.x,GridPos.y);
		goControl.z = GetGrid(GridPos).Height;
		goControl.Grid = GetGrid (GridPos);
		Grids [GridPos].Control = goControl;
	}
	Dictionary<int,Vector2> Direction=new Dictionary<int, Vector2>()
	{
		{1,new Vector2(0,-1)},
		{2,new Vector2(-1,0)},
		{3,new Vector2(-1,1)},
		{4,new Vector2(0,1)},
		{5,new Vector2(1,0)},
		{6,new Vector2(1,-1)}
	};

	public List<Vector2> Neighbours(Vector2 Center)
	{
		List<Vector2> TempN =new List<Vector2>();
		foreach(int i in Direction.Keys){
			if(GetGrid (Center+Direction[i])!=null)
						TempN.Add (Center+Direction[i]);
				}
		return TempN;
	}

	public HexGrids GetDirection(Vector2 Center,int i)
	{
		return GetGrid (Center + Direction [i]);
	}

	public List<Vector2> Ring(Vector2 RCenter,int RR)
	{
		List<Vector2> RingTemp = new List<Vector2> ();
		Vector2 PosTemp = RCenter + Direction [5] * RR;
		RingTemp.Add (PosTemp);
		for (int i=1; i<=Direction.Count; i++) {
			for(int j=0;j<RR;j++)
			{
				if(i==6&&j==RR-1)continue;
				PosTemp=PosTemp+Direction[i];
				RingTemp.Add (PosTemp);
			}
		}
		return RingTemp;
	}
	public List<Vector2> Area(Vector2 ACenter,int AR)
	{
		List<Vector2> AreaTemp = new List<Vector2> ();
		for (int i=0; i<=AR; i++) {
			foreach(Vector2 pos in Ring (ACenter,i))
				AreaTemp.Add (pos);
		}
		return AreaTemp;
	}

	//Distance means distance on the map without blocks
	public int CalcDistance(Vector2 Start,Vector2 End)
	{
		return Mathf.FloorToInt ((Mathf.Abs (Start.x - End.x) + Mathf.Abs (Start.y - End.y) + Mathf.Abs (Start.x + Start.y - End.x - End.y)) / 2);
	}

	public List<Vector2> FindPath(Vector2 Start,Vector2 End,Object Cell)
	{
//		float f;
//		float g;
//		float h;
		List<Vector2> Open=new List<Vector2>();
		List<Vector2> Close=new List<Vector2>();
		//A* calc path;
		return Close;
	}

	/*
	public void ShowArea(List<HexGrids> Area,int AreaStatus)
	{
		foreach (HexGrids G in Area) {
			ChangeGridObjectStatus (G,AreaStatus);
		}
		Debug.Log ("ShowArea");
	}
	*/

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
