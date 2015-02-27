using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridControl : MonoBehaviour {
	public static int Status;
	public static List<GridControl> ShowListA;
	public static List<GridControl> showListB;
	public Vector2 Pos;
	public int z;
	public GameObject Ground;
	public GameObject OutLine;
	public GameObject Inner;
	public int iStatus;
	//iStatus,0=None;1=MoveArea;2=AttackArea
	public int oStatus;
	//iStatus,0=None;1=Red;2=Green
	HexMap map;

	// Use this for initialization
	void Start () {
		ShowListA = new List<GridControl> ();
		showListB=new List<GridControl>();
		map=GameObject.Find ("Canvas").GetComponent<TestMain>().Map;
		iStatus = 0;
		oStatus = 0;
	}
	
	// Update is called once per frame
	void Update () {
	switch (iStatus) 
	{
		case 0:
		{
			Inner.gameObject.SetActive (false);
			break;
		}
		case 1:
		{
			Inner.gameObject.SetActive (true);
			Inner.gameObject.GetComponent<Image>().color=Color.blue;
			break;
		}
		case 2:
		{
			Inner.gameObject.SetActive (true);
			Inner.gameObject.GetComponent<Image>().color=Color.red;
			break;
		}
	}
	switch (oStatus) 
		{
		case 0:
		{
			OutLine.gameObject.SetActive (false);
			break;
		}
		case 1:
		{
			OutLine.gameObject.SetActive (true);
			OutLine.gameObject.GetComponent<Image>().color=Color.red;
			break;
		}
		}
	}

	public void OnClick(){
		if (Status == 0) 
		{
			foreach (Vector2 gPos in map.Neighbours (Pos)) 
			{
				map.Grids[gPos].gcGrid.iStatus = 1;
				ShowListA.Add (map.Grids[gPos].gcGrid);
				map.Grids[gPos].gcGrid.oStatus = 1;
				showListB.Add (map.Grids[gPos].gcGrid);
			}				
				Status = 1;
			return;
		}
		if (Status == 1&&iStatus != 1) 
		{
			Status=0;
			foreach(GridControl gc in ShowListA)
			{
				gc.iStatus=0;
			}
			ShowListA.Clear ();
			return;
		}
		if (Status == 3) {
			Status =4;
			iStatus=1;
			ShowListA.Add (map.Grids[Pos].gcGrid);
			Debug.Log ("Center:"+Pos);
			return;
		}
		if (Status == 4) {
			Status =5;
			int d=map.CalcDistance(Pos,ShowListA[0].Pos);
			Debug.Log ("Radius"+d);
			List<Vector2> AreaTemp=map.Area (ShowListA[0].Pos,d);
			foreach(Vector2 pos in AreaTemp)
			{
				if(!map.Grids.ContainsKey(pos))
					continue;
				map.Grids[pos].gcGrid.iStatus=1;
				ShowListA.Add (map.Grids[pos].gcGrid);
			}
			return;
		}
		if (Status == 5 && iStatus != 1) {
			Status=3;
			foreach(GridControl gc in ShowListA)
			{
				gc.iStatus=0;
			}
			ShowListA.Clear ();
			return;
		}
	}
}
