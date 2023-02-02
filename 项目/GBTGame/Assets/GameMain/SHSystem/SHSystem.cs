using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameFrameWork
{
    /// <summary>
    /// 显示与隐藏系统
    /// </summary>
    public class SHSystem
    {

        static Dictionary<string, ShowAndHide> panel_dic = new Dictionary<string, ShowAndHide>();//模板映射
        static Dictionary<string, string> parent_dic = new Dictionary<string, string>();//模板父窗口

        private SHSystem() { }

        private static SHSystem instance = new SHSystem();
        public static SHSystem Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 添加名称映射
        /// </summary>
        /// <param name="panel_name"></param>
        /// <param name="sh"></param>
        public void AddPanel(string panel_name, ShowAndHide sh)
        {
            if (panel_dic.ContainsKey(panel_name))
            {
                Debug.Log("已有！" + panel_name);
                return;
            }
            panel_dic.Add(panel_name, sh);
        }
        /// <summary>
        /// 设置父子映射
        /// </summary>
        /// <param name="sub_panel_name"></param>
        /// <param name="parent_panel_name"></param>
        public void SetPanelParent(string sub_panel_name, string parent_panel_name)
        {
            if (parent_dic.ContainsKey(sub_panel_name))
            {
                Debug.Log("已有！" + sub_panel_name + "的父子映射"!);
                return;
            }
            parent_dic.Add(sub_panel_name, parent_panel_name);

        }
        /// <summary>
        /// 回退到父窗口
        /// </summary>
        /// <param name="curr_panel_name"></param>
        public void Back(string curr_panel_name)
        {
            panel_dic[curr_panel_name].Hide();
            if (parent_dic.ContainsKey(curr_panel_name))
            {
                panel_dic[parent_dic[curr_panel_name]].Show();
            }
            else
            {
                Debug.Log(curr_panel_name + "没有父子映射");
            }
        }
        /// <summary>
        /// 显示指定窗口
        /// </summary>
        /// <param name="curr_name"></param>
        /// <param name="show_name"></param>
        public void Show(string curr_name, string show_name)
        {
            if (panel_dic.ContainsKey(curr_name) && panel_dic.ContainsKey(show_name))
            {
                panel_dic[curr_name].Hide();
                panel_dic[show_name].Show();
            }
        }
        /// <summary>
        /// 改变当前模板显示状态
        /// </summary>
        /// <param name="curr_name"></param>
        public void Change(string curr_name)
        {
            if (panel_dic.ContainsKey(curr_name))
            {
                panel_dic[curr_name].Change();
            }
            else
            {
                Debug.Log("没有" + curr_name);
            }
        }
        /// <summary>
        /// 改变当前模板为显示状态
        /// </summary>
        /// <param name="curr_name"></param>
        public void Show(string curr_name)
        {
            if (panel_dic.ContainsKey(curr_name))
            {
                panel_dic[curr_name].Show();
            }
            else
            {
                Debug.Log("没有" + curr_name);
            }
        }
        /// <summary>
        /// 改变当前模板为隐藏状态
        /// </summary>
        /// <param name="curr_name"></param>
        public void Hide(string curr_name)
        {
            if (panel_dic.ContainsKey(curr_name))
            {
                panel_dic[curr_name].Hide();
            }
            else
            {
                Debug.Log("没有" + curr_name);
            }
        }
    }
}


