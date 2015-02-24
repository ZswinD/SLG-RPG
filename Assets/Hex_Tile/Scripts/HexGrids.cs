using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrids
{
	public Object Cell{ get; set;}
	public Vector2 Position{ get; set;}
	public int Height{ get;set;}
	public LandForm Land{ get; set;}
	public int Status{ get; set;}
	//Hightlight Layer,OutLine Layer and Ground Layer;
	public GameObject Highlight{ get; set;}
	public GameObject Outline{ get; set;}
	public GameObject Ground{ get; set;}

	public static HexGrids NullGrid{get{return new HexGrids(-1);}}

	public HexGrids(int H)
	{
		Cell = default(Object);
		Position = Vector2.zero;
		Height = H;
		Land = ScriptableObject.CreateInstance <LandForm>();
		Status = 0;
	}

	public HexGrids(Vector2 Pos,int H) :this(H)
	{
		Position=Pos;
		Status = 1;
	}

}
