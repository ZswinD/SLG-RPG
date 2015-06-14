using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionBar{

	Dictionary<Character,int> ABValue=new Dictionary<Character, int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(List<Character> AllCharacter)
	{
		foreach (Character c in AllCharacter) {
						ABValue.Add (c, 0);
				}
	}

	public void Init(Character player,Character enemy)
	{
		ABValue.Add (player, 0);
		ABValue.Add (enemy, 0);
	}

	public int CharNum(){return ABValue.Count;}

	public Character ClacNextPlayer()
	{
		Character Next=Character.NormalChar;
		int MinTime = int.MaxValue;
		foreach (Character c in ABValue.Keys)
		{
			int tempTime;
			if((tempTime=(100-ABValue[c])/c.speed)<MinTime){
				MinTime=tempTime;
				Next=c;
			} 
		}
		Dictionary<Character,int> ABT = new Dictionary<Character, int> ();
		foreach(Character c in ABValue.Keys)
		{
			if(c==Next)
				ABT.Add (c,0);
			else
				ABT.Add (c,Mathf.Min (99,ABValue[c]+c.speed*MinTime));
		}
		ABValue = ABT;
		return Next;
	}

	public Dictionary<Character,int> GetValue()
	{
		return ABValue;
	}

}
