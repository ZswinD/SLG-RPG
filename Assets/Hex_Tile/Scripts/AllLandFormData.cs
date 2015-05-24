using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AllLandFormData:ScriptableObject{
	[SerializeField]
	public List<LandFormData> AllLandForm=new List<LandFormData>();
}