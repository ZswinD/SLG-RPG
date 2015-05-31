using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CmdSys;

public class WarData
{
	List<Character> AllChar=new List<Character>();
	List<WarCmd> TurnStartCmd=new List<WarCmd>();
	List<WarCmd> ActionStartCmd=new List<WarCmd>();
	List<WarCmd> BeforeAttackCmd=new List<WarCmd>();
	List<WarCmd> AttackingCmd=new List<WarCmd>();
	List<WarCmd> AfterAttackCmd=new List<WarCmd>();
	List<WarCmd> TurnEndCmd=new List<WarCmd>();
	public delegate void EventHandler(string CmdName,string[] CmdArgs);
	public event EventHandler Event;
}

public class WarCmd:Command
{
	string CmdName;
	string[] CmdArgs;

	WarCmd(string Name,string[] Args)
	{
		CmdName = Name;
		CmdArgs = Args;
	}

	public void DO(){Debug.Log("DO");}
	public void UNDO (){Debug.Log ("UNDO");}
	public void HELP(){Debug.Log ("HELP");}
	public void LOG(){Debug.Log ("LOG");}
}

public class War{

	bool IsWarEnd;
	bool ISSimpleWar=true;
	WarData data;
	List<WarData> DataList;


	public void DoSLGWar()
	{
		ISSimpleWar = false;
		WarStart ();
		ShowWarInfo ();
		while (!IsWarEnd) 
		{
			Character Next = CalcNextChar ();
			CharDoAction (Next);
			CalcAction ();
			IsWarEnd = IfWarEnd();
		}
	}

	public void DoSimpleWar()
	{
		ISSimpleWar = true;
		WarStart ();
		ShowWarInfo ();
		while (!IsWarEnd) 
		{
			Character AttChar=CalcAttChar();
			Character DefChar=CalcDefChar();
			DoAttack(AttChar,DefChar);
		}
	}

	public void WarStart()
	{
		IsWarEnd = false;
		if (ISSimpleWar) {
			Character Enemy=GetEnemy();
			data=LoadSimpleData();
		}
		else {
			LoadMapData ("Test");
			data=LoadCharData ();
		}
	}

	public Character GetEnemy()
	{
		return new Character();
	}

	public WarData LoadSimpleData()
	{
		return new WarData ();
	}

	public void LoadMapData(string MapName)
	{

	}

	public WarData LoadCharData()
	{
		LoadPlayerChar ();
		LoadEnemyChar ();
		return new WarData ();
	}

	public void LoadPlayerChar()
	{

	}

	public void LoadEnemyChar()
	{

	}

	public void ShowWarInfo()
	{

	}

	public Character CalcNextChar()
	{
		return new Character ();
	}

	public Character CalcAttChar()
	{
		return new Character ();
	}

	public Character CalcDefChar()
	{
		return new Character();
	}

	public void DoAttack(Character Att ,Character Def)
	{

	}

	public bool CharDoAction(Character C)
	{
		return true;
	}

	public void CalcAction()
	{

	}

	public bool IfWarEnd()
	{
		return true;
	}

	public void WarEnd()
	{

	}

}
