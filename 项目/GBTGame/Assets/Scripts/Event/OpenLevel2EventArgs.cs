using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/5 10:38:13
public class OpenLevel2EventArgs : IEventArgs
{
	public OpenLevel2EventArgs()
	{
	}

	public static OpenLevel2EventArgs Create()
	{
		return new OpenLevel2EventArgs();
	}
}

