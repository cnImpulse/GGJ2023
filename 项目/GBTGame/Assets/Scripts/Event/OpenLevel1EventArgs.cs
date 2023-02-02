using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 10:38:09
public class OpenLevel1EventArgs : IEventArgs
{
	public OpenLevel1EventArgs()
	{
	}

	public static OpenLevel1EventArgs Create()
	{
		return new OpenLevel1EventArgs();
	}
}

