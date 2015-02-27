using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrids
{
	public Object Cell{ get; set;}
	public Vector2 Position{ get; set;}
	public int Height{ get;set;}
	public LandForm Land{ get; set;}
	public GridControl gcGrid;

	public static HexGrids NullGrid{get{return new HexGrids(-1);}}

	public HexGrids(int H)
	{
		Cell = default(Object);
		Position = Vector2.zero;
		Height = H;
		Land = ScriptableObject.CreateInstance <LandForm>();
	}

	public HexGrids(Vector2 Pos,int H) :this(H)
	{
		Position=Pos;
	}

}
