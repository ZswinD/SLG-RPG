using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Land:EditorWindow
{
	[MenuItem("HexGrids/Land")]
	static void ShowLand(){
		Rect wr = new Rect (0, 0, 500, 500);
		Land window = (Land)EditorWindow.GetWindowWithRect <Land> (wr, false, "Lands");
		window.Show ();
	}
}