using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public delegate void TimerHandle();

    private Dictionary<int, Timer> timers;
    private List<Timer> removedTimers;
    private List<Timer> addedTimers;

    private int autoIncId;

    public int Count;

    public int AutoIncID
    {
        get
        {
            return autoIncId;
        }
    }

    public TimerManager()
    {
        timers = new Dictionary<int, Timer>();
        autoIncId = 0;
        removedTimers = new List<Timer>();
        addedTimers = new List<Timer>();
    }

    public Timer SetTimer(TimerHandle handle, float duration, float firstDelay, long repeatTimes = 0)
    {
        Timer timer = new Timer(handle, duration, firstDelay, repeatTimes, duration, false, autoIncId);
        addedTimers.Add(timer);
        autoIncId++;
        return timer;
    }

    public bool ClearTimer(int id)
    {
        if (!timers.ContainsKey(id))
        {
            return false;
        }

        Timer timer = timers[id];
        timer.Removed = true;
        return true;
    }

    public bool ClearTimer(Timer timer)
    {
        return ClearTimer(timer.TimerID);
    }

    private void Tick(float deltaTime)
    {
        foreach (var timer in addedTimers)
        {
            timers.Add(timer.TimerID, timer);
        }
        addedTimers.Clear();
        foreach (var timer in timers.Values)
        {
            if (timer.Removed)
            {
                removedTimers.Add(timer);
                continue;
            }

            timer.PassedTime += deltaTime;
            if (timer.PassedTime >= timer.FirstDelay + timer.Duration)
            {
                timer.Callback();
                timer.RepeatTimes--;
                timer.PassedTime -= timer.FirstDelay + timer.Duration;
                timer.FirstDelay = 0;
                if (timer.RepeatTimes == 0)
                {
                    timer.Removed = true;
                    removedTimers.Add(timer);
                }
            }
        }

        foreach (var timer in removedTimers)
        {
            timers.Remove(timer.TimerID);
        }
        removedTimers.Clear();
    }

    private static TimerManager instance;

    private void Start()
    {
        
    }

    private void Update()
    {
        Tick(Time.deltaTime);
        
        Count = timers.Count;
    }

    private void OnDestroy()
    {
        foreach (var timerKvp in timers)
        {
            ClearTimer(timerKvp.Key);
        }
    }

    public static TimerManager GetTimerManager()
    {
        if (!instance)
        {
            GameObject obj = Instantiate(Resources.Load("TimerManagerObject", typeof(GameObject)) as GameObject);
            instance = obj.GetComponent<TimerManager>();
        }

        return instance;
    }
}

public static class TimerManagerExtends
{
	public static TimerManager GetTimerManager(this MonoBehaviour getter)
	{
		return TimerManager.GetTimerManager();
	}
}