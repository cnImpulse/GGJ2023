using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	public TimerManager.TimerHandle Callback;
	public float Duration;
	public float FirstDelay;
	public long RepeatTimes;
	public float PassedTime;
	public bool Removed;
	public int TimerID;

	public Timer(TimerManager.TimerHandle callback, float duration, float firstDelay, long repeatTimes, float passedTime,
		bool removed, int timerID)
	{
		Callback = callback;
		Duration = duration;
		FirstDelay = firstDelay;
		RepeatTimes = repeatTimes;
		PassedTime = passedTime;
		Removed = removed;
		TimerID = timerID;
	}
}