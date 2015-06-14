using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum SkillType
{
	damage,
	area_damage,
	heal,
	area_heal,
	buff,
	debuff
}

public enum TargetArgs
{
	self,
	enemy,
	enemies,
	friends,
	all,
	target
}

public class SkillEffectArgs : EventArgs
{
	public SkillType type;
	public TargetArgs target;
	public int Damage;
}
