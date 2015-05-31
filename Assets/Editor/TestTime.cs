using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class TestTime: EditorWindow{
	[MenuItem("MyEditor/TestTime")]
	static void Test()
	{
		Stopwatch sw = new Stopwatch ();
		sw.Start ();
		for(int i=0;i<1000;i++)
		{
			//CycleMain
		}
		sw.Stop ();
		UnityEngine.Debug.Log (sw.Elapsed);
	}
}
