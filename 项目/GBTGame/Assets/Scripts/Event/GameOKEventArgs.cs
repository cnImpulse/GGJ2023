using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 13:12:25
public class GameOKEventArgs : IEventArgs
{
	public int level;
	public GameOKEventArgs(int _level)
	{
		level = _level;
	}

	public static GameOKEventArgs Create(int level)
	{
		return new GameOKEventArgs(level);
	}
}

