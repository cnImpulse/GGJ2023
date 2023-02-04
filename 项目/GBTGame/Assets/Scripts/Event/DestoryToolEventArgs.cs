using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/3 22:14:15
public class DestoryToolEventArgs : IEventArgs
{
	public GameObject obj;
	public bool isUnder;
	public DestoryToolEventArgs(GameObject _obj, bool _isUnder)
	{
		obj = _obj;
		this.isUnder = _isUnder;
	}

	public static DestoryToolEventArgs Create(GameObject obj, bool _isUnder)
	{
		return new DestoryToolEventArgs(obj,_isUnder);
	}
}

