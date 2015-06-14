using UnityEngine;
using System.Collections;

public class SimpleWarData : WarData
{
	public SimpleWarMap map;
	public Character player;
	public Character enemy;
	public SimpleWarData(SimpleWarMap mymap,Character myplayer){
		map = mymap;
		player = myplayer;
	}
}

public class SimpleWar : War{

	SimpleWarData data;
	float TurnTime=0.2f;
	public bool Stop;

	public IEnumerator DoSimpleWar(SimpleWarData SimpleData)
	{
		Stop = false;
		LoadData (SimpleData);
		data.enemy=GetEnemy ();
		WarStart ();
		InitATB ();	
		GameObject.FindObjectOfType<SimpleWarTest>().enemyManager.Init (data.enemy);
		int i = 0;
		while (!IsWarEnd) 
		{
			Character AttChar=CalcAttChar();
			Character DefChar=CalcDefChar(AttChar);
			AttChar.CalcUseSkill().Use(AttChar,DefChar);
			IsWarEnd=IfWarEnd ();
			yield return new WaitForSeconds(TurnTime);
			if(Stop)
				return true;
		}
		if (WarResult () == 1)
						Debug.Log ("Player Wins!");
				else 
						Debug.Log ("Player Lose!");
		WarEnd ();
		GameObject.FindObjectOfType<SimpleWarTest> ().IfWarStarted = true;
	}

	public override void LoadData (WarData wardata)
	{
		data = (SimpleWarData)wardata;
	}

	public Character GetEnemy()
	{
		return (data.map.SelectEnemy());
	}

	public override void WarStart()
	{
		Debug.Log ("A Simple War Begins");
		Debug.Log ("Player: " + data.player.Name);
		Debug.Log ("Enemy: " + data.enemy.Name);
		IsWarEnd = false;
	}

	public override void InitATB ()
	{
		ATB = new ActionBar ();
		ATB.Init (data.player, data.enemy);
	}

	public override void ShowWarInfo ()
	{
		Debug.Log ("Player:" + data.player.Name);
		Debug.Log ("Enemy:" + data.enemy.Name);
	}
	
	public override bool IfWarEnd ()
	{
		if (data.player.IsAlive ()&&data.enemy.IsAlive ())
						return false;
				else
						return true;
	}

	public override void WarEnd ()
	{
		data.player.exp += 10;
		Debug.Log ("A Simple War End");
	}

	public override void ShowCharInfo ()
	{
	}

	public override int WarResult ()
	{
		return	data.enemy.IsAlive()? 0 : 1;
	}

	public override void WarEndEffect ()
	{
		return;
	}

	public Character CalcAttChar()
	{
		return ATB.ClacNextPlayer();
	}
	
	public Character CalcDefChar(Character Attacker)
	{
		if (Attacker == data.player)
						return data.enemy;
				else
						return data.player;
	}

	public void DoAttack(Character Att ,Character Def)
	{
		Att.Attack.Use (Att, Def);
	}

	public void ShowPlayerData()
	{
		return;
	}

	public void ShowEnemyData()
	{
		return;
	}

	public void SetTurnTime(float t)
	{
		TurnTime = t;
	}
}
