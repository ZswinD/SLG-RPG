using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMain : MonoBehaviour {
	void Start(){
		HexMap TestMap = new HexMap ();
		TestMap = MapXml.LoadMap ("Test");
		TestMap.Draw ();
	}
}
