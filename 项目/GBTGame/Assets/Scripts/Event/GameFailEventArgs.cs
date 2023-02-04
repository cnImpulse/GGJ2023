using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/4 15:31:05
public class GameFailEventArgs : IEventArgs
{
	public GameFailEventArgs()
	{
	}

	public static GameFailEventArgs Create()
	{
		return new GameFailEventArgs();
	}
}

