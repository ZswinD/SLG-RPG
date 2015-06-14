using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class PullDownList: MonoBehaviour {

	public int value;
	public Text MyTitle;
	public Button NowSelection;
	public VerticalLayoutGroup List;
	public Dictionary<int,string> AllSelection;
	
	public UnityEvent OnValueChange=new UnityEvent();

	// Use this for initialization
	void Start () {
		List.gameObject.SetActive (false);
		NowSelection.onClick.AddListener (() => List.gameObject.SetActive (true));
	}

	public void Init(int Value,Dictionary<int,string> allSelection)
	{
		AllSelection = allSelection;
		NowSelection.GetComponentInChildren<Text> ().text = AllSelection [Value];
		foreach(int i in AllSelection.Keys) {
			Button SelectionTemp=GameObject.Instantiate<Button>(NowSelection);
			SelectionTemp .GetComponentInChildren<Text> ().text = AllSelection [i];
			SelectionTemp.gameObject.transform.SetParent (List.gameObject.transform);
			int j=i;
			SelectionTemp.onClick.AddListener(()=>ChangeValue(j));
		}
		RectTransform NowRectTran = NowSelection.GetComponent<RectTransform> ();
		List.GetComponent<RectTransform> ().sizeDelta = new Vector2 (NowRectTran.sizeDelta.x, NowRectTran.sizeDelta.y*AllSelection.Count);
	}

	void ChangeValue(int myvalue)
	{
		value = myvalue;
		List.gameObject.SetActive (false);
		OnValueChange.Invoke();
		NowSelection.GetComponentInChildren<Text> ().text = AllSelection [value];
	}
	

	public int GetValue()
	{
		return value;
	}
}
