using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LandFormData:ScriptableObject{
	public List<int> ID=new List<int>();
	public List<string> Name=new List<string>();
	public List<DictionaryOfIntAndFloat> Effect = new List<DictionaryOfIntAndFloat> (); 
}