using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/1 15:58:31
public class DeveloperEventArgs : IEventArgs
{
	public DeveloperEventArgs()
	{
	}

	public static DeveloperEventArgs Create()
	{
		return new DeveloperEventArgs();
	}
}

