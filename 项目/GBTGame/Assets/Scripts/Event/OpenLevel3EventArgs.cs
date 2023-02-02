using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 10:38:18
public class OpenLevel3EventArgs : IEventArgs
{
	public OpenLevel3EventArgs()
	{
	}

	public static OpenLevel3EventArgs Create()
	{
		return new OpenLevel3EventArgs();
	}
}

