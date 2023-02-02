using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/6 9:52:27
public class SaveSkillEventArgs : IEventArgs
{
	public int lastKill;
	public int defence;
	public int attack;
	public int attackSpeed;
	public SaveSkillEventArgs(int _lastKill, int _defence, int _attack, int _attackSpeed)
	{
		lastKill = _lastKill;
		defence = _defence;
		attack = _attack;
		attackSpeed = _attackSpeed;
	}

	public static SaveSkillEventArgs Create(int lastKill, int defence, int attack, int attackSpeed)
	{
		return new SaveSkillEventArgs(lastKill, defence, attack, attackSpeed);
	}
}

