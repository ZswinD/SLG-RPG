using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill {
	public int ID{ get; set;}
	public string Name{ get; set;}
	public Dictionary<string,float> EffectArgs = new Dictionary<string, float> ();
	public void LoadSkillInfo(string info)
	{

	}
	public void Use(Character User,Character Target=null)
	{

	}
}
