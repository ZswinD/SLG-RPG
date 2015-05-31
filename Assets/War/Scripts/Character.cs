using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character{
	public string Name{ get; set;}
	public int Level{ get; set;}
	public int exp{ get; set;}
	public int group{ get; set;}
	public int att{ get; set;}
	public int def{ get; set;}
	public int move{ get; set;}
	public int speed{ get; set;}
	public string Job{ get; set;}
	public List<Skill> Skills=new List<Skill>();
}
