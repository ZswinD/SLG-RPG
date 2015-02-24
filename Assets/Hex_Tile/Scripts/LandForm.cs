using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandForm:ScriptableObject
{
	public int ID{ get; set;}
	public string Name{ get; set;}
	public Dictionary<int,float> Effect;

	public LandForm()
	{
		ID = 0;
		Effect = new Dictionary<int,float>();
		Name = "default";
	}

	public string PrintInfo()
	{
		string strInfo = "LandForm Info :\n";
		foreach (int leId in Effect.Keys) {

		}
		strInfo+=("End LandInfo");
		return strInfo;
	}
}
