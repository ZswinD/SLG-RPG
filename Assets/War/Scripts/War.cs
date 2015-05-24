using UnityEngine;
using System.Collections;

public class War{

	bool IsWarEnd;

	public void DoSLGWar()
	{
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
		WarStart ();
		ShowWarInfo ();

	}

	public void WarStart()
	{
		IsWarEnd = false;
		LoadMapData("Test");
		LoadCharData();
	}

	public void LoadMapData(string MapName)
	{

	}

	public void LoadCharData()
	{
		LoadPlayerChar ();
		LoadEnemyChar ();
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
