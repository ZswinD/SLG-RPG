using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandForm
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

	public LandForm (int id, string name, Dictionary<int,float> effect)
	{
		ID = id;
		Name = name;
		Effect = effect;
	}


	public string PrintInfo()
	{
		string strInfo = "LandForm Info :\n";
		Debug.Log (ID);
		Debug.Log (Name);
		foreach (int leId in Effect.Keys) {
			Debug.Log (leId+" "+Effect[leId]);
		}
		strInfo+=("End LandInfo");
		return strInfo;
	}
}
