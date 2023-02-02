using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameFrameWork
{
    /// <summary>
    /// ��ʾ������ϵͳ
    /// </summary>
    public class SHSystem
    {

        static Dictionary<string, ShowAndHide> panel_dic = new Dictionary<string, ShowAndHide>();//ģ��ӳ��
        static Dictionary<string, string> parent_dic = new Dictionary<string, string>();//ģ�常����

        private SHSystem() { }

        private static SHSystem instance = new SHSystem();
        public static SHSystem Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// �������ӳ��
        /// </summary>
        /// <param name="panel_name"></param>
        /// <param name="sh"></param>
        public void AddPanel(string panel_name, ShowAndHide sh)
        {
            if (panel_dic.ContainsKey(panel_name))
            {
                Debug.Log("���У�" + panel_name);
                return;
            }
            panel_dic.Add(panel_name, sh);
        }
        /// <summary>
        /// ���ø���ӳ��
        /// </summary>
        /// <param name="sub_panel_name"></param>
        /// <param name="parent_panel_name"></param>
        public void SetPanelParent(string sub_panel_name, string parent_panel_name)
        {
            if (parent_dic.ContainsKey(sub_panel_name))
            {
                Debug.Log("���У�" + sub_panel_name + "�ĸ���ӳ��"!);
                return;
            }
            parent_dic.Add(sub_panel_name, parent_panel_name);

        }
        /// <summary>
        /// ���˵�������
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
                Debug.Log(curr_panel_name + "û�и���ӳ��");
            }
        }
        /// <summary>
        /// ��ʾָ������
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
        /// �ı䵱ǰģ����ʾ״̬
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
                Debug.Log("û��" + curr_name);
            }
        }
        /// <summary>
        /// �ı䵱ǰģ��Ϊ��ʾ״̬
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
                Debug.Log("û��" + curr_name);
            }
        }
        /// <summary>
        /// �ı䵱ǰģ��Ϊ����״̬
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
                Debug.Log("û��" + curr_name);
            }
        }
    }
}


