using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 1:03:59
public class KillMonsterEventArgs : IEventArgs
{
	public int Wave;
	public KillMonsterEventArgs(int _Wave)
	{
		Wave = _Wave;
	}

	public static KillMonsterEventArgs Create(int Wave)
	{
		return new KillMonsterEventArgs(Wave);
	}
}

