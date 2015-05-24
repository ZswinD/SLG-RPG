using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrids
{
	public Object Cell{ get; set;}
	public GridControl Control{ get; set;}
	public int Height{ get;set;}
	public int Land{ get; set;}

	public static HexGrids NullGrid{get{return new HexGrids(-1);}}
	public static HexGrids DefaultGrid{ get { return new HexGrids (1); } }

	public HexGrids(int H)
	{
		Cell = default(Object);
		Land = 0;
	}

	public HexGrids(int H,int LandID) :this(H)
	{
		Land = LandID;
	}
}
