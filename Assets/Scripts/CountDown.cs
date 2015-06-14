using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.Events;
using System;

public class CountDown : MonoBehaviour {

	public int Count;
	public System.TimeSpan TimeCount;
	public string REText="'CountDown'";
	int CountDownInt;
	System.TimeSpan CountDownTime;
	Text CountDownText;
	Regex RE=new Regex("'CountDown'");
	bool IsTime=false;
	bool IsStart=false;
	float startTime=0;

	public UnityEvent End=new UnityEvent();

	void Awake(){
		CountDownText = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		CountDownText.text=string.Empty;
	}

	public void StartCountDown()
	{
		CountDownInt = Count;
		startTime = Time.fixedTime;
		IsTime = false;
		IsStart = true;
	}

	public void StartCountDown(int NumToCount,string text="'CountDown'")
	{
		REText = text;
		Count = NumToCount;
		StartCountDown ();
	}

	public void StartCountDown(System.TimeSpan TimeToCount,string text="'CountDown'")
	{
		REText = text;
		TimeCount = TimeToCount;
		CountDownTime = TimeToCount;
		startTime = Time.fixedTime;
		IsTime = true;
		IsStart = true;
	}

	public void StartCountDown(int NumToCount,UnityAction EndAction,string text="'CountDown'")
	{
		End.AddListener (EndAction);
		StartCountDown (NumToCount,text);
	}
	public void StartCountDown(System.TimeSpan TimeToCount,UnityAction EndAction,string text="'CountDown'")
	{
		End.AddListener (EndAction);
		StartCountDown (TimeToCount,text);
	}
	
	// Update is called once per frame
	void Update () {
		if (IsStart == false)
			return;
		if (IsTime) 
		{
			float timespen=Time.fixedTime-startTime;
			CountDownTime=TimeCount-new System.TimeSpan(0,0,(int)timespen);
			CountDownText.text = RE.Replace (REText,CountDownTime.ToString ());
			if(CountDownTime<=System.TimeSpan.Zero)
			{
				IsStart=false;
				CountDownText.text=string.Empty;
				End.Invoke();
				End.RemoveAllListeners ();
			}
		}
		else
		{
			float timespen=Time.fixedTime-startTime;
			CountDownInt=Count-(int)timespen;
			CountDownText.text = RE.Replace (REText,CountDownInt.ToString ());
			if(CountDownInt<=0)
			{
				IsStart=false;
				CountDownText.text=string.Empty;
				End.Invoke ();
				End.RemoveAllListeners ();
			}
		}
	}
}
