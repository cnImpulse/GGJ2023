using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/3 22:14:15
public class DestoryToolEventArgs : IEventArgs
{
	public GameObject obj;
	public DestoryToolEventArgs(GameObject _obj)
	{
		obj = _obj;
	}

	public static DestoryToolEventArgs Create(GameObject obj)
	{
		return new DestoryToolEventArgs(obj);
	}
}

