using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMain : MonoBehaviour {

	public HexMap Map;
	public int TestStatus=1;

	void Start(){
		Map = ScriptableObject.CreateInstance <HexMap>();
		Map=MapXml.LoadMap ("Default");
		if(Map!=null)
		Map.Draw ();
		GridControl.Status = TestStatus;
	}
}
