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
        const int SW_SHOWMINIMIZED = 2; //����С��, �����  
        const int SW_SHOWMAXIMIZED = 3;//���  
        const int SW_SHOWRESTORE = 1;//��ԭ  
        public static void OnClickMinimize()//��С�� 
        {
            ShowWindow(GetForegroundWindow(), SW_SHOWMINIMIZED);
        }

        public static void OnClickMaximize()
        {
            //���  
            ShowWindow(GetForegroundWindow(), SW_SHOWMAXIMIZED);
        }
        public static void OnClickRestore()
        {
            //��ԭ  
            ShowWindow(GetForegroundWindow(), SW_SHOWRESTORE);
        }
        //����  
    }
}