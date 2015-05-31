using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LandEffectData:ScriptableObject{
	public List<int> ID=new List<int>();
	public List<string> Name=new List<string>();
	public List<string> Key = new List<string> ();
	public List<string> Desc = new List<string> ();
}
