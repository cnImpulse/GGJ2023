using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[Serializable]
public abstract class ValuePresetEventList<T>
{
	[SerializeField, Tooltip("你要这个事件列表在被监测值为多少时被执行")]
	protected T preset;

	public T Preset
	{
		get
		{
			return preset;
		}
	}
	
	[Space(35f)]

	[SerializeField]
	private UnityEvent events;

	public UnityEvent Event
	{
		get
		{
			return events;
		}
	}
	
	public ValuePresetEventList(T preset, params UnityAction[] actions)
	{
		this.preset = preset;
		events = new UnityEvent();
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	public abstract bool Qualified(T val);
	/*{
		if (typeof(T) == typeof(float) || typeof(T) == typeof(double))
		{
			return 
		}
		return val.Equals(preset);
	}*/

	
}

[Serializable]
public class CommonPresetEventList<T> : ValuePresetEventList<T>
{
	public CommonPresetEventList(T preset, params UnityAction[] actions)
		: base(preset, actions)
	{
		
	}
	
	public override bool Qualified(T val)
	{
		return preset.Equals(val);
	}
}

[Serializable]
public class FloatPresetEventList : ValuePresetEventList<float>
{
	private float tolerance;

	public FloatPresetEventList(float preset, params UnityAction[] actions)
		: base(preset, actions)
	{
		this.tolerance = 1e-3f;
	}
	
	public FloatPresetEventList(float preset, float tolerance, params UnityAction[] actions)
		: base(preset, actions)
	{
		this.tolerance = tolerance;
	}

	public override bool Qualified(float val)
	{
		return Mathf.Abs(preset - val) < tolerance;
	}
}

[Serializable]
public class DoublePresetEventList : ValuePresetEventList<double>
{
	private double tolerance;
	
	public DoublePresetEventList(float preset, params UnityAction[] actions)
		: base(preset, actions)
	{
		this.tolerance = 1e-6;
	}
	
	public DoublePresetEventList(double preset, double tolerance, params UnityAction[] actions)
		: base(preset, actions)
	{
		this.tolerance = tolerance;
	}

	public override bool Qualified(double val)
	{
		return Math.Abs(preset - val) < tolerance;
	}
}

[Serializable]
public class StringPresetEventList : ValuePresetEventList<string>
{
	public StringPresetEventList(string preset, params UnityAction[] actions)
		: base(preset, actions)
	{
		
	}

	public override bool Qualified(string val)
	{
		return (preset == val);
	}
}