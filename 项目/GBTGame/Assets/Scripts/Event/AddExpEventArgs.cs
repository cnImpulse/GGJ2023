using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
//CreateTime：2022/11/6 8:47:05
public class AddExpEventArgs : IEventArgs
{
	public int exp;
	public AddExpEventArgs(int _exp)
	{
		exp = _exp;
	}

	public static AddExpEventArgs Create(int exp)
	{
		return new AddExpEventArgs(exp);
	}
}

