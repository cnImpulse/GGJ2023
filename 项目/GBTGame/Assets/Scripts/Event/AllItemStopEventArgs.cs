using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2023/2/4 12:38:31
public class AllItemStopEventArgs : IEventArgs
{
	public AllItemStopEventArgs()
	{
	}

	public static AllItemStopEventArgs Create()
	{
		return new AllItemStopEventArgs();
	}
}

