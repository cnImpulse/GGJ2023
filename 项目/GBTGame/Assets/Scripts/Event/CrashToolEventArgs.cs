using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/4 11:05:11
public class CrashToolEventArgs : IEventArgs
{
	public GameObject obj;
	public CrashToolEventArgs(GameObject _obj)
	{
		obj = _obj;
	}

	public static CrashToolEventArgs Create(GameObject obj)
	{
		return new CrashToolEventArgs(obj);
	}
}

