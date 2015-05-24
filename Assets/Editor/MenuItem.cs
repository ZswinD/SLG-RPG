using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MenuItemControl : EditorWindow
{	
	[MenuItem("MyEditor/AllDescToObject")]
	static void DescToObject()
	{
		DescManager.AllDescToObject ();
	}

	[MenuItem("MyEditor/OutputAssetBundle")]
	static void OutputAssetBundle()
	{
		DescManager.OutputAssetBundle ();
	}
}