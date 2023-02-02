using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameFrameWork
{
    /// <summary>
    /// 控制器管理系统
    /// </summary>
    public class ControlSystem
    {
        Dictionary<string, BaseControl> control_dic = new Dictionary<string, BaseControl>();

        private ControlSystem() { }
        //单例模式
        private static ControlSystem instance = new ControlSystem();
        public static ControlSystem Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 根据控制器名称获取控制器
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
                Debug.Log("没有" + control_name + "的控件");
                return null;
            }
        }

        /// <summary>
        /// 注册控制器名称
        /// </summary>
        public void AddControl(string control_name, BaseControl control)
        {
            if (control_dic.ContainsKey(control_name))
            {
                Debug.Log("已有该控件");
            }
            else
            {
                control_dic.Add(control_name, control);
            }
        }
    }
}



