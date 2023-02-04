using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/4 15:30:29
public class GameSucceedEventArgs : IEventArgs
{
	public int level;
	public int index;
	public GameSucceedEventArgs(int _level, int _index)
	{
		level = _level;
		index = _index;
	}

	public static GameSucceedEventArgs Create(int level, int index)
	{
		return new GameSucceedEventArgs(level, index);
	}
}

