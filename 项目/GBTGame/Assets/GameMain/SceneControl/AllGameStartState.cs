using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class AllGameStartState : ISceneState
    {
        bool isFisrt;
        public AllGameStartState(SceneStateC c) : base(c)
        {
            this.StateName = "AllGameStartState";
            isFisrt = true;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFisrt)
            {
                isFisrt = false;
                EventManagerSystem.Instance.Add2(Data_EventName.BackStartGame_str, OnBackStartGame);
            }
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_AllGameStartForm);
            //SoundSystem.Instance.PlayMusic(Data_AudioID.key_Dark_Journey);//≤•∑≈“Ù¿÷
           
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {
            //EventManagerSystem.Instance.Add2(Data_EventName.BackStartGame_str, OnBackStartGame);
        }

        private void OnBackStartGame(IEventArgs eventArgs)
        {
            m_Contorller.SetState("StartState", null);
        }
    }
}

