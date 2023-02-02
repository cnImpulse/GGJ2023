using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameFrameWork
{
    /// <summary>
    /// ����������ϵͳ
    /// </summary>
    public class ControlSystem
    {
        Dictionary<string, BaseControl> control_dic = new Dictionary<string, BaseControl>();

        private ControlSystem() { }
        //����ģʽ
        private static ControlSystem instance = new ControlSystem();
        public static ControlSystem Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// ���ݿ��������ƻ�ȡ������
        /// </summary>
        /// <param name="control_name"></param>
        /// <returns></returns>
        public BaseControl GetControl(string control_name)
        {
            if (control_dic.ContainsKey(control_name))
            {
                return control_dic[control_name];
            }
            else
            {
                Debug.Log("û��" + control_name + "�Ŀؼ�");
                return null;
            }
        }

        /// <summary>
        /// ע�����������
        /// </summary>
        public void AddControl(string control_name, BaseControl control)
        {
            if (control_dic.ContainsKey(control_name))
            {
                Debug.Log("���иÿؼ�");
            }
            else
            {
                control_dic.Add(control_name, control);
            }
        }
    }
}



