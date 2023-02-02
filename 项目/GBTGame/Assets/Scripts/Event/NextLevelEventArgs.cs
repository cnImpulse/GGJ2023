using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/6 0:29:43
public class NextLevelEventArgs : IEventArgs
{
	public int Level;
	public NextLevelEventArgs(int _Level)
	{
		Level = _Level;
	}

	public static NextLevelEventArgs Create(int Level)
	{
		return new NextLevelEventArgs(Level);
	}
}

