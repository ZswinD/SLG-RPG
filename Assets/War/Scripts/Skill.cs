using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill {
	public int ID{ get; set;}
	public string Name{ get; set;}
	public SkillEffectArgs SEArgs{ get; set;}

	public Skill()
	{
		ID = 1;
		Name = "Attack";
		SEArgs = new SkillEffectArgs ();
		SEArgs.type = SkillType.damage;
		SEArgs.target = TargetArgs.enemy;
		SEArgs.Damage = 1;
	}

	public void LoadSkillInfo(int id)
	{

	}

	public void Use(Character User,Character Target=null)
	{
		if (Target == null) {
			Debug.Log (User.Name + " USE SKILL " + this.Name);
		} else {
			Debug.Log (User.Name + " USE SKILL  " + this.Name + " TO " + Target.Name);
			Target.Hurt (User.att,User,100);
		}
	}
}
