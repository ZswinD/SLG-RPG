using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridClick : MonoBehaviour {
	public Button AB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ABC(){
		AB = gameObject.GetComponent<Button> ();
		Debug.Log ("123");
	}
}
