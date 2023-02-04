using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class TimeSystem : MonoBehaviour
    {
        public float clock_time;

        bool isgoon = true;//时钟是否继续
        private TimeSystem()
        {
            isgoon = true;//默认开启
        }
        //单例模式
        private static TimeSystem instance = new TimeSystem();
        public static TimeSystem Instance
        {
            get { return instance; }
        }
        void Start()
        {
            StartCoroutine(TimeClock());//开始时钟计时
        }
        /// <summary>
        /// 设置时钟时间
        /// </summary>
        /// <param name="tick_time"></param>
        public void SetClockTime(float tick_time)
        {
            clock_time = tick_time;
        }
        /// <summary>
        /// 设置时钟开关
        /// </summary>
        /// <param name="flag"></param>
        public void SetGoOn(bool flag)
        {
            isgoon = flag;
            //EventManagerSystem.Instance.Add("时钟",)
        }
        /// <summary>
        /// 时钟计时器
        /// </summary>
        /// <returns></returns>
        IEnumerator TimeClock()
        {
            while (true)
            {
                yield return new WaitForSeconds(clock_time);
                //Debug.Log("触发时钟");
                if (isgoon)
                    EventManagerSystem.Instance.Invoke("时钟");
            }
        }
    }
}

