using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DataCs;



namespace MyGameFrameWork
{
    public class MenuState : ISceneState
    {

        bool isFisrt;

        GameObject Enity1;
        GameObject HpBarCanvas;
        public MenuState(SceneStateC c) : base(c)
        {
            this.StateName = "MenuState";
            isFisrt = true;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFisrt)
            {
                isFisrt = false;
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.OpenLevel1_str, OpenLevel1);
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.OpenLevel2_str, OpenLevel2);
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.OpenLevel3_str, OpenLevel3);
                EventManagerSystem.Instance.Add2(Data_EventName.BackStartGame_str, OnBackStartGame);
                EventManagerSystem.Instance.Add2(Data_EventName.OpenSkill_str, OnOpenSkillOpen);
            }
            /*SkillAdditionSystem.CreateInstance(0, 0, 0);
            
            EventManagerSystem.Instance.Add2(DataCs.Data_EventName.KillMonster_str, KillMonster);
            Enity1 = m_Contorller.GetData("Enity1") as GameObject;
            Enity1?.SetActive(true);*/

            //HpBarCanvas = m_Contorller.GetData("HpBarCanvas") as GameObject;

            UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm);

            //CreateMainUI();
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {
            /*EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.GameOver_str, GameOver);
            EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.KillMonster_str, KillMonster);*/
            /*EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.OpenLevel1_str, OpenLevel1);
            EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.OpenLevel2_str, OpenLevel2);
            EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.OpenLevel3_str, OpenLevel3);
            EventManagerSystem.Instance.Delete2(Data_EventName.BackStartGame_str, OnBackStartGame);
            EventManagerSystem.Instance.Delete2(Data_EventName.OpenSkill_str, OnOpenSkillOpen);*/
        }

        void CreateMainUI()
        {
            Debug.Log("asdas");
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_MenuForm);
        }

        void OpenLevel1(IEventArgs eventArgs)
        {
            m_Contorller.SetState("MainState",0);
        }

        void OpenLevel2(IEventArgs eventArgs)
        {
            m_Contorller.SetState("MainState", 1);
        }

        void OpenLevel3(IEventArgs eventArgs)
        {
            m_Contorller.SetState("MainState", 2);
        }

        private void OnBackStartGame(IEventArgs eventArgs)
        {
            m_Contorller.SetState("StartState", null);
        }

        private void OnOpenSkillOpen(IEventArgs eventArgs)
        {
            m_Contorller.SetState("SkillState", null);
        }


        /*void KillMonster(IEventArgs eventArgs)
        {
            KillMonsterEventArgs killMonsterEventArgs = (KillMonsterEventArgs)eventArgs;
            int killWave = killMonsterEventArgs.Wave;
        }*/
    }
}

