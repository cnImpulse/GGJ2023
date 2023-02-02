using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/1 15:30:10
public class StartGameEventArgs : IEventArgs
{
	public StartGameEventArgs()
	{
	}

	public static StartGameEventArgs Create()
	{
		return new StartGameEventArgs();
	}
}

