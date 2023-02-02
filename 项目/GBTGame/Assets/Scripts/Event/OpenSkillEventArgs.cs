using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/6 9:51:39
public class OpenSkillEventArgs : IEventArgs
{
	public OpenSkillEventArgs()
	{
	}

	public static OpenSkillEventArgs Create()
	{
		return new OpenSkillEventArgs();
	}
}

