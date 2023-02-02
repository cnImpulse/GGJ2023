using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/1 15:30:29
public class ExitGameEventArgs : IEventArgs
{
	public ExitGameEventArgs()
	{
	}

	public static ExitGameEventArgs Create()
	{
		return new ExitGameEventArgs();
	}
}

