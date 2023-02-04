using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class TimeSystem : MonoBehaviour
    {
        public float clock_time;

        bool isgoon = true;//ʱ���Ƿ����
        private TimeSystem()
        {
            isgoon = true;//Ĭ�Ͽ���
        }
        //����ģʽ
        private static TimeSystem instance = new TimeSystem();
        public static TimeSystem Instance
        {
            get { return instance; }
        }
        void Start()
        {
            StartCoroutine(TimeClock());//��ʼʱ�Ӽ�ʱ
        }
        /// <summary>
        /// ����ʱ��ʱ��
        /// </summary>
        /// <param name="tick_time"></param>
        public void SetClockTime(float tick_time)
        {
            clock_time = tick_time;
        }
        /// <summary>
        /// ����ʱ�ӿ���
        /// </summary>
        /// <param name="flag"></param>
        public void SetGoOn(bool flag)
        {
            isgoon = flag;
            //EventManagerSystem.Instance.Add("ʱ��",)
        }
        /// <summary>
        /// ʱ�Ӽ�ʱ��
        /// </summary>
        /// <returns></returns>
        IEnumerator TimeClock()
        {
            while (true)
            {
                yield return new WaitForSeconds(clock_time);
                //Debug.Log("����ʱ��");
                if (isgoon)
                    EventManagerSystem.Instance.Invoke("ʱ��");
            }
        }
    }
}

