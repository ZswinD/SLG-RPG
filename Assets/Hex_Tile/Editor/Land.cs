using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Land:EditorWindow
{
	public string s="Hello World";
	[MenuItem("HexGrids/Land")]
	static void ShowLand(){
		Rect wr = new Rect (0, 0, 200, 300);
		Land window = (Land)EditorWindow.GetWindowWithRect <Land> (wr, false, "Lands");
		window.Show ();
	}
	void OnGUI()
	{
		GUILayout.Label ("Land");
		s = GUILayout.TextField (s);
		if (GUILayout.Button ("Debug"))
						Debug.Log (s);
	}
}