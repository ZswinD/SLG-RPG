using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandForm
{
	public string Name{ get; set;}
	public int NumOfEffect{ get; set;}
	public List<LandEffect> Effect;

	public LandForm(int i)
	{
		NumOfEffect = i;
		Effect = new List<LandEffect> (i);
	}
	public LandForm():this(0){Name = "default";}
	public LandForm(string name,int i):this(i)
	{
		Name = name;
	}
	public LandForm LoadLand(string LandName)
	{
		Debug.Log ("Load Landform from datebase...");
		return new LandForm ();
	}
}
