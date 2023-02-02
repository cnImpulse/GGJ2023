using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/6 1:39:50
public class MainTowerInjureEventArgs : IEventArgs
{
	public float DPS;
	public MainTowerInjureEventArgs(float _DPS)
	{
		DPS = _DPS;
	}

	public static MainTowerInjureEventArgs Create(float DPS)
	{
		return new MainTowerInjureEventArgs(DPS);
	}
}

