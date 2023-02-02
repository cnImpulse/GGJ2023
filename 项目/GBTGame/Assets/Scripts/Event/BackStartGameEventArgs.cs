using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/1 16:29:07
public class BackStartGameEventArgs : IEventArgs
{
	public BackStartGameEventArgs()
	{
	}

	public static BackStartGameEventArgs Create()
	{
		return new BackStartGameEventArgs();
	}
}

