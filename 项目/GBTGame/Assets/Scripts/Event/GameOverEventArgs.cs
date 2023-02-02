using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 1:03:00
public class GameOverEventArgs : IEventArgs
{
	public GameOverEventArgs()
	{
	}

	public static GameOverEventArgs Create()
	{
		return new GameOverEventArgs();
	}
}

