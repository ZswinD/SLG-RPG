using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InSimpleWarManager:InWarManager 
{
	public Text Name,Level,Exp,HP,Job,Att,Def,Speed;
	public Character me;

	void Start()
	{
	}

	void Update ()
	{
		if (me == null)
						return;
		ShowData ();
	}

	public void Init(Character c)
	{
		SetCharacter (c);
	}

	void SetCharacter(Character MyCharacter)
	{
		me = MyCharacter;
		me.myManager = this;
		MyCharacter.InitSimpleWarManager ();
		ShowData ();
	}

	void ShowData()
	{
		Name.text = me.Name;
		Level.text ="Lv."+me.Level.ToString ();
		Exp.text = "Exp:" + me.exp.ToString ();
		HP.text = "HP:" + hp_now.ToString () + "/" + me.hp.ToString ();
		Job.text = "Job:" + me.Job;
		Att.text = "Att:" + me.att.ToString ();
		Def.text = "Def:" + me.def.ToString ();
		Speed.text = "Speed:" + me.speed.ToString ();
	}
	public void Clear()
	{
		Name.text = string.Empty;
		Level.text = string.Empty;
		Exp.text = string.Empty;
		HP.text = string.Empty;
		Job.text = string.Empty;
		Att.text =string.Empty;
		Def.text =string.Empty;
		Speed.text =string.Empty;
	}

}
