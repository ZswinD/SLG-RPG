using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CmdSys;

public class WarData
{
	public delegate void EventHandler(string CmdName,string[] CmdArgs);
	public event EventHandler WarEvent;
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

public abstract class War{

	protected bool IsWarEnd;
	protected WarData data;
	protected ActionBar ATB;

	public abstract void LoadData(WarData wardata);

	public abstract void WarStart ();

	public abstract void InitATB();

	public abstract void ShowWarInfo ();

	public abstract bool IfWarEnd ();

	public abstract void WarEnd ();

	public abstract int WarResult();

	public abstract void WarEndEffect();

	public abstract void ShowCharInfo();
	
}
