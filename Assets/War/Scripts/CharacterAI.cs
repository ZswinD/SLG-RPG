using UnityEngine;
using System.Collections;

public enum AIStyle
{
	PC,
	NPC
}

public enum Difficulty
{
	Easy,
	Normal,
	Hard,
	Hell
}


public class CharacterAI
{
	public Character me;
	public AIStyle AIStyle;
	public Difficulty AIDifficulty;

	public void DefaultAttack()
	{
		me.Attack.Use(me);
	}

}
