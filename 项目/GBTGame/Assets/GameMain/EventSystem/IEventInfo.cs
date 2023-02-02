using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MyGameFrameWork
{
    public interface IEventInfo
    {

    }

    public class EventInfo : IEventInfo
    {
        public UnityAction action;
        public EventInfo(UnityAction Action)
        {
            action = Action;
        }
    }

    public class EventInfo<T> : IEventInfo
    {
        public UnityAction<T> action;
        public EventInfo(UnityAction<T> Action)
        {
            action = Action;
        }
    }

    public class EventInfo<T1, T2> : IEventInfo
    {
        public UnityAction<T1, T2> action;
        public EventInfo(UnityAction<T1, T2> Action)
        {
            action = Action;
        }
    }

    public interface IEventArgs
    {

    }
}


