using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[Serializable]
public abstract class ValueChangedEvents<T>
{
	protected bool inProgress;

	public bool InProgress
	{
		get
		{
			return inProgress;
		}
	}

	protected T monitored;
	
	private readonly float fixedTick;
	
	[SerializeField, Header("重载监听器参数")]
	public bool OverrideMonitorOptions;
	[SerializeField, Min(0f)]
	protected float monitorTick;

	protected float tick
	{
		get
		{
			return OverrideMonitorOptions ? monitorTick : fixedTick;
		}
	}

	public ValueChangedEvents(ref T val, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f)
	{
		monitored = val;
		fixedTick = Time.deltaTime;
		OverrideMonitorOptions = overrideMonitorOptions;
		monitorTick = tick;
	}

	protected virtual T Monitored
	{
		get
		{
			return monitored;
		}
		set
		{
			T temp = monitored;
			monitored = value;
			if (!temp.Equals(monitored))
			{
				Invoke();
			}
		}
	}

	private Timer keepTimer;

	public void BeginMonitor()
	{
		inProgress = true;
		keepTimer = TimerManager.GetTimerManager().SetTimer(Keep, tick, tick, 0);
	}

	public void BeginMonitor(ref T property)
	{
		BindProperty(ref property);
		BeginMonitor();
	}

	public void EndMonitor()
	{
		inProgress = false;
		if (!TimerManager.GetTimerManager().ClearTimer(keepTimer))
		{
			throw new Exception("解除监听器Timer失败！");
		}
		//Debug.Log(string.Format($"{ToString()} {GetHashCode()}.EndMonitor"));
	}
	
	public abstract void BindProperty(ref T property);
	
	public abstract void Invoke();
	
	protected abstract T ptrValue { get; }
	
	//protected abstract bool pointerNotNull { get; }

	protected virtual void Keep()
	{
		if (!inProgress) return;
		Monitored = ptrValue;
	}
}

#region INT

public unsafe abstract class IntChangedEventsBase : ValueChangedEvents<int>
{
	private int* ptr;
	
	public IntChangedEventsBase(ref int integer, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f)
		: base(ref integer, overrideMonitorOptions, newMonitorTick)
	{
		this.BindProperty(ref integer);
	}

	public override void BindProperty(ref int property)
	{
		fixed (int* temp = &property)
		{
			ptr = temp;
		}
	}

	protected override int ptrValue
	{
		get
		{
			if (ptr == null)
			{
				EndMonitor();
				return monitored;
			}
			return *ptr;
		}
	}

	/*protected override bool pointerNotNull
	{
		get
		{
			return (ptr != null);
		}
	}*/
}

[Serializable]
public unsafe class IntChangedEvents : IntChangedEventsBase
{
	[SerializeField]
	private UnityEvent events;

	public UnityEvent Event
	{
		get
		{
			return events;
		}
	}

	public IntChangedEvents(ref int integer, params UnityAction[] actions)
		:base(ref integer)
	{
		events = new UnityEvent();
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	public IntChangedEvents(ref int integer, float newMonitorTick, params UnityAction[] actions)
		:base(ref integer, true, newMonitorTick)	
	{
		events = new UnityEvent();
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	public override void Invoke()
	{
		events.Invoke();
	}

}

[Serializable]
public unsafe sealed class IntChangedEventsWithPresets : IntChangedEventsBase
{
	[SerializeField]
	private List<CommonPresetEventList<int>> integerPresetEventList;

	private Dictionary<int, UnityEvent> ieDict;

	public List<CommonPresetEventList<int>> EventList
	{
		get
		{
			return integerPresetEventList;
		}
		private set
		{
			integerPresetEventList = new List<CommonPresetEventList<int>>(value);
		}
	}
	
	public IntChangedEventsWithPresets(ref int integer, params CommonPresetEventList<int>[] presetEventLists)
		:base(ref integer)
	{
		EventList = presetEventLists.ToList();

		ieDict = new Dictionary<int, UnityEvent>();
		foreach (var preset in integerPresetEventList)
		{
			ieDict.Add(preset.Preset, preset.Event);
		}
	}

	public IntChangedEventsWithPresets(ref int integer, float newMonitorTick, params CommonPresetEventList<int>[] presetEventLists)
		:base(ref integer, true, newMonitorTick)
	{
		EventList = presetEventLists.ToList();
		
		ieDict = new Dictionary<int, UnityEvent>();
		foreach (var preset in integerPresetEventList)
		{
			ieDict.Add(preset.Preset, preset.Event);
		}
	}

	public void Init()
	{
		ieDict = new Dictionary<int, UnityEvent>();
		foreach (var preset in integerPresetEventList)
		{
			ieDict.Add(preset.Preset, preset.Event);
		}
	}
	
	public override void Invoke()
	{
		//Debug.LogWarning("Enter IntChangedEventsWithPresets.Invoke");
		/*foreach (var presetEvent in EventList)
		{
			if (presetEvent.Qualified(Monitored))
			{
				Debug.LogWarning(presetEvent.ToString() + ".Event.Invoke");
				presetEvent.Event.Invoke();
			}
		}*/

		/*if (ieDict == null)
		{
			Debug.LogWarning("ieDict == null");
			return;
		}*/
		if (ieDict.ContainsKey(Monitored))
			ieDict[Monitored].Invoke();
	}
}

#endregion

#region FLOAT

[Serializable]
public unsafe abstract class FloatChangedEventsBase : ValueChangedEvents<float>
{
	private float* ptr;

	private readonly float fixedTolerance;
	
	[SerializeField]
	private float tolerance;

	public FloatChangedEventsBase(ref float single, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f, float newTolerance = 1e-3f)
		: base(ref single, overrideMonitorOptions, newMonitorTick)
	{
		fixedTolerance = 1e-3f;
		tolerance = newTolerance;
		this.BindProperty(ref single);
	}

	protected float Tolerance
	{
		get
		{
			return OverrideMonitorOptions ? tolerance : fixedTolerance;
		}
	}

	protected override float Monitored
	{
		get
		{
			return monitored;
		}
		set
		{
			float temp = monitored;
			monitored = value;
			if (Mathf.Abs(temp - monitored) >= Tolerance)
			{
				Invoke();
			}
		}
	}

	public override void BindProperty(ref float property)
	{
		fixed (float* temp = &property)
		{
			ptr = temp;
		}
	}

	protected override float ptrValue
	{
		get
		{
			if (ptr == null)
			{
				EndMonitor();
				return monitored;
			}
			return *ptr;
		}
	}

	/*protected override bool pointerNotNull
	{
		get
		{
			return (ptr != null);
		}
	}*/
}

[Serializable]
public unsafe sealed class FloatChangedEvents : FloatChangedEventsBase
{
	[SerializeField]
	private UnityEvent events;
	
	public UnityEvent Event
	{
		get
		{
			return events;
		}
	}
	
	public FloatChangedEvents(ref float single, params UnityAction[] actions)
		: base(ref single)
	{
		events = new UnityEvent();
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	public override void Invoke()
	{
		events.Invoke();
	}
}

[Serializable]
public unsafe sealed class FloatChangedEventsWithPresets : FloatChangedEventsBase
{
	[SerializeField]
	private List<FloatPresetEventList> singlePresetEventList;

	public List<FloatPresetEventList> EventList
	{
		get
		{
			return singlePresetEventList;
		}
		private set
		{
			singlePresetEventList = new List<FloatPresetEventList>(value);
		}
	}
	
	public FloatChangedEventsWithPresets(ref float single, params FloatPresetEventList[] presetEventLists)
		: base(ref single)
	{
		EventList = presetEventLists.ToList();
	}

	public FloatChangedEventsWithPresets(ref float single, float newMonitorTick, float newTolerance,
		params FloatPresetEventList[] presetEventLists)
		: base(ref single, true, newMonitorTick, newTolerance)
	{
		EventList = presetEventLists.ToList();
	}
	
	public void Init()
	{
		
	}

	public override void Invoke()
	{
		foreach (var presetEvent in EventList)
		{
			if (presetEvent.Qualified(Monitored))
			{
				presetEvent.Event.Invoke();
			}
		}
	}
}

#endregion

#region DOUBLE

[Serializable]
public unsafe abstract class DoubleChangedEventsBase : ValueChangedEvents<double>
{
	private double* ptr;

	private readonly double fixedTolerance;
	
	[SerializeField]
	private double tolerance;

	public DoubleChangedEventsBase(ref double doubled, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f, double newTolerance = 1e-5f)
		: base(ref doubled, overrideMonitorOptions, newMonitorTick)
	{
		fixedTolerance = 1e-6;
		tolerance = newTolerance;
		this.BindProperty(ref doubled);
	}

	protected double Tolerance
	{
		get
		{
			return OverrideMonitorOptions ? tolerance : fixedTolerance;
		}
	}

	protected override double Monitored
	{
		get
		{
			return monitored;
		}
		set
		{
			double temp = monitored;
			monitored = value;
			if (Math.Abs(temp - monitored) >= Tolerance)
			{
				Invoke();
			}
		}
	}

	public override void BindProperty(ref double property)
	{
		fixed (double* temp = &property)
		{
			ptr = temp;
		}
	}

	protected override double ptrValue
	{
		get
		{
			if (ptr == null)
			{
				EndMonitor();
				return monitored;
			}
			return *ptr;
		}
	}

	/*protected override bool pointerNotNull
	{
		get
		{
			return (ptr != null);
		}
	}*/
}

[Serializable]
public unsafe sealed class DoubleChangedEvents : DoubleChangedEventsBase
{
	[SerializeField]
	private UnityEvent events;
	
	public UnityEvent Event
	{
		get
		{
			return events;
		}
	}
	
	public DoubleChangedEvents(ref double doubled, params UnityAction[] actions)
		: base(ref doubled)
	{
		events = new UnityEvent();
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	public override void Invoke()
	{
		events.Invoke();
	}
}

[Serializable]
public unsafe sealed class DoubleChangedEventsWithPresets : DoubleChangedEventsBase
{
	[SerializeField]
	private List<DoublePresetEventList> doublePresetEventList;

	public List<DoublePresetEventList> EventList
	{
		get
		{
			return doublePresetEventList;
		}
		private set
		{
			doublePresetEventList = new List<DoublePresetEventList>(value);
		}
	}
	
	public DoubleChangedEventsWithPresets(ref double doubled, params DoublePresetEventList[] presetEventLists)
		: base(ref doubled)
	{
		EventList = presetEventLists.ToList();
	}

	public DoubleChangedEventsWithPresets(ref double doubled, float newMonitorTick, float newTolerance,
		params DoublePresetEventList[] presetEventLists)
		: base(ref doubled, true, newMonitorTick, newTolerance)
	{
		EventList = presetEventLists.ToList();
	}

	public override void Invoke()
	{
		foreach (var presetEvent in EventList)
		{
			if (presetEvent.Qualified(Monitored))
			{
				presetEvent.Event.Invoke();
			}
		}
	}
}

#endregion

#region BOOLEAN

[Serializable]
public unsafe sealed class BooleanChangedEvents : ValueChangedEvents<bool>
{
	private bool* ptr;

	[SerializeField]
	private UnityEvent whenTrue;

	[SerializeField]
	private UnityEvent whenFalse;

	public BooleanChangedEvents(ref bool boolean, UnityAction[] tActions = null, UnityAction[] fActions = null)
		: base(ref boolean)
	{
		whenTrue = new UnityEvent();
		whenFalse = new UnityEvent();
		if (tActions != null) foreach (var action in tActions)
		{
			whenTrue.AddListener(action);
		}
		if (fActions != null) foreach (var action in fActions)
		{
			whenFalse.AddListener(action);
		}
		this.BindProperty(ref boolean);
	}

	public BooleanChangedEvents(ref bool boolean, float newMonitorTick, UnityAction[] tActions = null, UnityAction[] fActions = null)
		: base(ref boolean, true, newMonitorTick)
	{
		whenTrue = new UnityEvent();
		whenFalse = new UnityEvent();
		if (tActions != null) foreach (var action in tActions)
		{
			whenTrue.AddListener(action);
		}
		if (fActions != null) foreach (var action in fActions)
		{
			whenFalse.AddListener(action);
		}
		this.BindProperty(ref boolean);
	}

	public override void BindProperty(ref bool property)
	{
		fixed (bool* temp = &property)
		{
			ptr = temp;
		}
	}

	protected override bool ptrValue
	{
		get
		{
			if (ptr == null)
			{
				EndMonitor();
				return monitored;
			}
			return *ptr;
		}
	}

	/*protected override bool pointerNotNull
	{
		get
		{
			return (ptr != null);
		}
	}*/

	public override void Invoke()
	{
		if (Monitored)
		{
			whenTrue?.Invoke();
		}
		else
		{
			whenFalse?.Invoke();
		}
	}
}

#endregion

/*#region ENUM

public unsafe sealed class EnumChangedEvents<T> : IntChangedEvents where T : Enum
{
	private IntPtr ptr;

	private static int useless = 0;
	
	public EnumChangedEvents(ref T enumerator, float newMonitorTick = 0.1f, params UnityAction[] actions)
		: base(ref enumerator, newMonitorTick, actions)
	{
		enumerator.
		this.BindProperty(ref enumerator);
	}

	protected override T ptrValue
	{
		get
		{
			
			return (T)(*ptr.ToPointer());
		}
	}

	private void BindProperty(ref Enumerable property)
	{
		fixed (int* temp = &property)
	}
}

#endregion*/

/*public abstract unsafe class EnumChangedEventsBase<T> : ValueChangedEvents<Enum> where T : class
{
	private Enum ptr;
	
	public EnumChangedEventsBase(ref Enum enumerator, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f)
		:base(ref enumerator, overrideMonitorOptions, newMonitorTick)
	{
		this.BindProperty(ref enumerator);
	}

	public override void BindProperty(ref Enum property)
	{
		ptr = property;
	}

	protected override Enum Monitored
	{
		get
		{
			return ptr;
		}
		set
		{
			T temp = monitored as T;
			monitored = value;
			if (!temp.Equals(monitored))
			{
				Invoke();
			}
		}
	}

	protected override Enum ptrValue { get; }

	protected override bool pointerNotNull
	{
		get
		{
			return ptr != null;
		}
	}

	protected override IEnumerator Keep()
	{
		//Debug.LogWarning("Enter Keep");
		//Debug.LogWarning(pointerNotNull);
		while (inProgress && pointerNotNull)
		{
			//Debug.LogWarning("In Keep");
			Monitored = ptr;
			yield return new WaitForSeconds(tick);
		}
	}
}*/

/*[Serializable]
public unsafe class EnumChangedEvents<T> : EnumChangedEventsBase<T> where T : class
{
	[SerializeField]
	private UnityEvent events;
	
	public UnityEvent Event
	{
		get
		{
			return events;
		}
	}
	
	public EnumChangedEvents(ref Enum enumerator, params UnityAction[] actions)
		:base(ref enumerator)
	{
		foreach (var action in actions)
		{
			events.AddListener(action);
		}
	}

	protected override void Invoke()
	{
		events.Invoke();
	}
}*/

/*public unsafe class EnumChangedEventsBase<T> : ValueChangedEvents<Enum> where T : struct, IConvertible
{
	public EnumChangedEventsBase(ref Enum enumerator, bool overrideMonitorOptions = false, float newMonitorTick = 0.1f)
		: base(ref enumerator, overrideMonitorOptions, newMonitorTick)
	{
		this.BindProperty(ref enumerator);
	}
}*/