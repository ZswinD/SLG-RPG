using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LandFormData:ScriptableObject{
	public int ID;
	public string Name;
	public List<int> EffectID = new List<int> ();
	public List<float> EffectValue = new List<float>();
}