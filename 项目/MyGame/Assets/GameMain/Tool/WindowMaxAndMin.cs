using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MyGameFrameWork
{
    public class WindowMaxAndMin : MonoBehaviour
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        const int SW_SHOWMINIMIZED = 2; //｛最小化, 激活｝  
        const int SW_SHOWMAXIMIZED = 3;//最大化  
        const int SW_SHOWRESTORE = 1;//还原  
        public static void OnClickMinimize()//最小化 
        {
            ShowWindow(GetForegroundWindow(), SW_SHOWMINIMIZED);
        }

        public static void OnClickMaximize()
        {
            //最大化  
            ShowWindow(GetForegroundWindow(), SW_SHOWMAXIMIZED);
        }
        public static void OnClickRestore()
        {
            //还原  
            ShowWindow(GetForegroundWindow(), SW_SHOWRESTORE);
        }
        //测试  
    }
}