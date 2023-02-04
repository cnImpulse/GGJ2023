using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class StartState : ISceneState
    {

        bool isFisrtStart ;

        public StartState(SceneStateC c) : base(c)
        {
            isFisrtStart = false;
            this.StateName = "StartState";
        }

        public override void StateBegin(System.Object obj)
        {
            GGJDataManager.Instance.Init();
            //��ʼʱ
            if (!isFisrtStart)
            {
                //SoundSystem.Instance.PlayMusic(Data_AudioID.key_GameBgm);//��������
                
                isFisrtStart = true;

                EventManagerSystem.Instance.Add2(Data_EventName.StartGame_str, OnStartGame);
                EventManagerSystem.Instance.Add2(Data_EventName.ExitGame_str, OnExitGame);
                EventManagerSystem.Instance.Add2(Data_EventName.Developer_str, OnDevelopers);
            }
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_StartGameForm);//��UI
        }

        public override void StateUpdate()
        {

        }

        public override void StateEnd()
        {
            //����ʱ
            SoundSystem.Instance.StopMusic(Data_AudioID.key_GameBgm);//��������
            EventManagerSystem.Instance.Delete2(Data_EventName.StartGame_str, OnStartGame);
            EventManagerSystem.Instance.Delete2(Data_EventName.ExitGame_str, OnExitGame);
            EventManagerSystem.Instance.Delete2(Data_EventName.Developer_str, OnDevelopers);
        }

        private void OnStartGame(IEventArgs eventArgs)//��Ϸ��ʼ
        {
            m_Contorller.SetState("MenuState", null);

        }

        private void OnDevelopers(IEventArgs eventArgs)//�����߽���
        {
            m_Contorller.SetState("EndGameState", null);
        }

        private void OnExitGame(IEventArgs eventArgs)//��Ϸ����
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}

