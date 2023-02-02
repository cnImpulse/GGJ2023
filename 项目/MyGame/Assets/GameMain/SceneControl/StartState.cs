using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class StartState : ISceneState
    {
        bool isLogin;
        public StartState(SceneStateC c) : base(c)
        {
            this.StateName = "StartState";
        }

        public override void StateBegin(System.Object obj)
        {
            //UISystem.Instance.OpenUIForm(Data_UIFormID.key_LoginForm);
            //isLogin = false;
            //EventManagerSystem.Instance.Add2(Data_EventName.OnLoginSucceed_str, LoginSucceed);
        }

        public override void StateUpdate()
        {
            if (isLogin)//µÇÂ¼³É¹¦Ìø×ª
            {
                //m_Contorller.SetState(Data_StateName.MainState_name, username);
            }
        }

        public override void StateEnd()
        {

        }

        private void LoginSucceed(IEventArgs eventArgs)
        {
            
        }
    }
}

