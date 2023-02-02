using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class EndGameState : ISceneState
    {
        bool isFirst;
        public EndGameState(SceneStateC c) : base(c)
        {
            this.StateName = "EndGameState";
            isFirst = true;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFirst)
            {
                EventManagerSystem.Instance.Add2(Data_EventName.BackStartGame_str, OnBackStartGame);
                isFirst = false;
            }
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_DeveloperForm);
            //SoundSystem.Instance.PlayMusic(Data_AudioID.key_Dark_Journey);//≤•∑≈“Ù¿÷
            
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {

            //SoundSystem.Instance.StopMusic(Data_AudioID.key_Dark_Journey);//≤•∑≈“Ù¿÷
        }

        private void OnBackStartGame(IEventArgs eventArgs)
        {
            m_Contorller.SetState("StartState", null);
        }
    }
}

