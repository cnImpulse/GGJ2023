///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class DisplayNameAttribute : PropertyAttribute
{
	public string Name;
	
    public DisplayNameAttribute(string name)
    {
	    Name = name;
    }
}
