using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public abstract class InWarManager : MonoBehaviour 
{
	public int hp_now{ get; set; }
	public bool IsAlive{ get; set;}
	public CharacterAI myAI{ get; set; }
	public Dictionary<Status,int> myStatusList;
}
