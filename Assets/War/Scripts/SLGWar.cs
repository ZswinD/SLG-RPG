using UnityEngine;
using System.Collections;

public class SLGWarData:WarData{

}

public class SLGWar : War {
	
	WarData data;
	
	public void DoSLGWar(WarData SLGData)
	{
		data = SLGData;
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

	public override void LoadData (WarData wardata)
	{
		data = wardata;
	}
	
	public override void WarStart()
	{
		Debug.Log ("SimpleWar");
	}

	public override void InitATB ()
	{
		return;
	}

	public override void ShowCharInfo ()
	{
		return;
	}

	public override int WarResult ()
	{
		return 0;
	}

	public override void ShowWarInfo ()
	{
		Debug.Log ("WarInfo");
	}
	
	public override bool IfWarEnd ()
	{
		return true;
	}
	
	public override void WarEnd ()
	{
		Debug.Log ("WarEnd");
	}

	public override void WarEndEffect ()
	{
		return;
	}

	public Character CalcNextChar()
	{
		return Character.NormalChar;
	}

	public bool CharDoAction(Character C)
	{
		return true;
	}
	
	public void CalcAction()
	{
		
	}

}
