using UnityEngine;
using System.Collections;

public class LandEffect
{
	public int ID{ get; set;}
	public string Name{ get; set;}
	public string Key{ get; set;}
	public string Desc{ get; set;}

	public LandEffect (){;}

	public LandEffect(int id,string name,string key,string desc)
	{
		ID = id;
		Name = name;
		Key = key;
		Desc = desc;
	}
}
