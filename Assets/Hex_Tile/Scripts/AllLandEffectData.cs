using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AllLandEffectData:ScriptableObject{
	[SerializeField]
	public List<LandEffectData> AllLandEffect=new List<LandEffectData>();
}
