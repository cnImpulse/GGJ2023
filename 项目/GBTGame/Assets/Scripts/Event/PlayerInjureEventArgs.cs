using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 9:17:29
public class PlayerInjureEventArgs : IEventArgs
{
	public float DPS;
	public PlayerInjureEventArgs(float _DPS)
	{
		DPS = _DPS;
	}

	public static PlayerInjureEventArgs Create(float DPS)
	{
		return new PlayerInjureEventArgs(DPS);
	}
}

