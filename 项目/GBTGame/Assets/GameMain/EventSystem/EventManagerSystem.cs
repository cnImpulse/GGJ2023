using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyGameFrameWork
{
    /// <summary>
    /// 事件管理系统
    /// </summary>
    public class EventManagerSystem
    {
        static Dictionary<string, IEventInfo> UnityActionDic = new Dictionary<string, IEventInfo>();//事件注册字典
        private EventManagerSystem() { }
        //单例模式
        private static EventManagerSystem instance = new EventManagerSystem();
        public static EventManagerSystem Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 无参注册方法
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Add(string EventName, UnityAction Action)
        {
            //Debug.Log(EventName+" 添加成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo).action += Action;
            }
            else//没有包含则需要注册
            {
                UnityActionDic.Add(EventName, new EventInfo(Action));
            }
        }
        /// <summary>
        /// 无参取消注册函数
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Delete(string EventName, UnityAction Action)
        {
            //Debug.Log(EventName + " 删除成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo).action -= Action;
            }
        }
        /// <summary>
        /// 无参触发函数
        /// </summary>
        /// <param name="EventName"></param>
        public void Invoke(string EventName)
        {
            //Debug.Log(EventName + " 调用成功!");

            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo).action.Invoke();//调用
            }
        }
        /// <summary>
        /// 一参注册方法
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Add<T>(string EventName, UnityAction<T> Action)
        {
            //Debug.Log(EventName + " 添加成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T>).action += Action;
            }
            else//没有包含则需要注册
            {
                UnityActionDic.Add(EventName, new EventInfo<T>(Action));
            }
        }
        /// <summary>
        /// 一参取消注册函数
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Delete<T>(string EventName, UnityAction<T> Action)
        {
            //Debug.Log(EventName + " 删除成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T>).action -= Action;
            }
        }
        /// <summary>
        /// 一参触发函数
        /// </summary>
        /// <param name="EventName"></param>
        public void Invoke<T>(string EventName, T val)
        {
            //Debug.Log(EventName + " 调用成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T>).action.Invoke(val);//调用
            }
        }
        /// <summary>
        /// 二参注册方法
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Add<T1, T2>(string EventName, UnityAction<T1, T2> Action)
        {
            //Debug.Log(EventName + " 添加成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T1, T2>).action += Action;
            }
            else//没有包含则需要注册
            {
                UnityActionDic.Add(EventName, new EventInfo<T1, T2>(Action));
            }
        }
        /// <summary>
        /// 二参取消注册函数
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Delete<T1, T2>(string EventName, UnityAction<T1, T2> Action)
        {
            //Debug.Log(EventName + " 删除成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T1, T2>).action -= Action;
            }
        }
        /// <summary>
        /// 二参触发函数
        /// </summary>
        /// <param name="EventName"></param>
        public void Invoke<T1, T2>(string EventName, T1 val1, T2 val2)
        {
            //Debug.Log(EventName + " 调用成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<T1, T2>).action.Invoke(val1, val2);//调用
            }
            else
            {
                Debug.Log("没有" + EventName + "这个事件");
            }
        }

        /// <summary>
        /// 支持任意形式任意个数的参数
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Add2(string EventName, UnityAction<IEventArgs> Action)
        {
            //Debug.Log(EventName + " 添加成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<IEventArgs>).action += Action;
            }
            else//没有包含则需要注册
            {
                UnityActionDic.Add(EventName, new EventInfo<IEventArgs>(Action));
            }
        }


        /// <summary>
        /// 任意参数删除
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="Action"></param>
        public void Delete2(string EventName, UnityAction<IEventArgs> Action)
        {
            //Debug.Log(EventName + " 删除成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<IEventArgs>).action -= Action;
            }
        }

        /// <summary>
        /// 任意参数调用
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="val"></param>
        public void Invoke2(string EventName, IEventArgs val)
        {
            //Debug.Log(EventName + " 调用成功!");
            if (UnityActionDic.ContainsKey(EventName))//表示已经包含该事件
            {
                (UnityActionDic[EventName] as EventInfo<IEventArgs>)?.action.Invoke(val);//调用
            }
        }

        /// <summary>
        /// 清空整个注册表
        /// </summary>
        public void Clean()
        {
            UnityActionDic.Clear();
        }
    }
}


