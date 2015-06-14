using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleWarManager : MonoBehaviour {

	public SimpleWar myWar;
	public InputField timeInput;

	public void InitTimeInput()
	{
		timeInput.onEndEdit.AddListener ((string s)=>myWar.SetTurnTime (float.Parse(s)));
	}

	// Use this for initialization
	void Start () {
		myWar = GameObject.FindObjectOfType<SimpleWarTest> ().mywar;
		InitTimeInput ();
	}

	// Update is called once per frame
	void Update () {
	}
}
