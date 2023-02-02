using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{

    public class ShowAndHide : MonoBehaviour
    {
        static Vector3 show = new Vector3(1, 1, 1);
        int flag = 0;//0表示为初始化,1表示有CanvasGroup,2表示没有
        bool isShow = false;

        CanvasGroup cg;
        public void Show()
        {
            isShow = true;
            if (flag == 0)
            {
                cg = GetComponent<CanvasGroup>();
                if (cg == null)
                {
                    flag = 2;
                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                cg.alpha = 1;
                cg.interactable = true;
                cg.blocksRaycasts = true;
            }
            else
            {
                gameObject.transform.localScale = show;
            }
        }
        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide()
        {
            isShow = false;
            if (flag == 0)
            {
                cg = GetComponent<CanvasGroup>();
                if (cg == null)
                {
                    flag = 2;
                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                cg.alpha = 0;
                cg.interactable = false;
                cg.blocksRaycasts = false;
            }
            else
            {
                gameObject.transform.localScale = Vector3.zero;
            }

        }
        /// <summary>
        /// 显示模式交换
        /// </summary>
        public void Change()
        {
            if (isShow)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

}