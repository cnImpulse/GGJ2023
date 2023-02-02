using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class MainState : ISceneState
    {
        public MainState(SceneStateC c) : base(c)
        {
            this.StateName = "MainState";
        }

        public override void StateBegin(System.Object obj)
        {
            //Debug.Log("MainState");
            Debug.Log("进入主界面");
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_MainForm, obj);
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {
            //Debug.Log("MainState End");
        }
    }
}

