using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Character{

	public string Name{ get; set;}
	public int Level{ get; set;}
	public int exp{ get; set;}
	public int hp{ get; set; }
	public int att{ get; set;}
	public int def{ get; set;}
	public int move{ get; set;}
	public int speed{ get; set;}
	public string Job{ get; set;}
	public Skill Attack=new Skill();
	public List<Skill> Skills=new List<Skill>();
	public InWarManager myManager;

	public static Character NormalChar{get{return new Character("TestChar");}}

	public Character(string name)
	{
		Name = name;
		Level = 1;
		exp = 0;
		hp = 10;
		att = 1;
		def = 1;
		move = 1;
		speed = 1;
		Job="starter";
		Attack = new Skill ();
		Skills.Clear ();
	}

	public void InitSimpleWarManager()
	{
		myManager.hp_now = hp;
		myManager.IsAlive = true;
		myManager.myStatusList = new Dictionary<Status,int> ();
	}

	public void Hurt(int Dmg,Character DmgHitter,int Persent)
	{
		int DmgFin = Dmg * Persent / 100;
		myManager.hp_now -= DmgFin;
		Debug.Log (DmgHitter.Name + " Do " + DmgFin + " Damage To " + Name);
		if (myManager.hp_now <= 0) {
			Die ();
		}
	}

	public void Die()
	{
		myManager.IsAlive = false;
		Debug.Log (Name + " Is Dead!");
	}

	public bool IsAlive()
	{
		return myManager.IsAlive;
	}

	public Skill CalcUseSkill()
	{
		return Attack;
	}

	public event EventHandler<SkillEffectArgs> Attacking;
	
	public event EventHandler<SkillEffectArgs> BeforeAttack;

	public event EventHandler<SkillEffectArgs> BeforeAttacked;
	
	public event EventHandler<SkillEffectArgs> Attacked;
	
}
