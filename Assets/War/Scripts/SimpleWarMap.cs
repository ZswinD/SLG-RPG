using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleWarMap{
	string Name;
	List<Character> Enemy;
	Dictionary<int,int> EnemySelect;

	public SimpleWarMap(string name)
	{
		Name = name;
		Enemy = new List<Character> ();
		EnemySelect = new Dictionary<int, int> ();
	}

	public Character SelectEnemy()
	{
		return Character.NormalChar;
	}

}
