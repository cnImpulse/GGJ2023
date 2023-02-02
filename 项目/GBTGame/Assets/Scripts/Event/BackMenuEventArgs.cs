using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 11:02:30
public class BackMenuEventArgs : IEventArgs
{
	public BackMenuEventArgs()
	{
	}

	public static BackMenuEventArgs Create()
	{
		return new BackMenuEventArgs();
	}
}

