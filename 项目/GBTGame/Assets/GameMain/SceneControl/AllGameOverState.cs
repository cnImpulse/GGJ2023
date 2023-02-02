using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class AllGameOverState : ISceneState
    {

        bool isFirst;
        public AllGameOverState(SceneStateC c) : base(c)
        {
            this.StateName = "AllGameOverState";
            isFirst = false;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFirst)
            {
                EventManagerSystem.Instance.Add2(Data_EventName.Developer_str, OnDevelopers);
                isFirst = false;
            }

            UISystem.Instance.OpenUIForm(Data_UIFormID.key_AllGameOverForm);
            //SoundSystem.Instance.PlayMusic(Data_AudioID.key_Dark_Journey);//播放音乐
            
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {
            //EventManagerSystem.Instance.Delete2(Data_EventName.Developer_str, OnDevelopers);
            //SoundSystem.Instance.StopMusic(Data_AudioID.key_Dark_Journey);//播放音乐
        }

        private void OnDevelopers(IEventArgs eventArgs)//开发者界面
        {
            m_Contorller.SetState("EndGameState", null);
        }
    }
}

