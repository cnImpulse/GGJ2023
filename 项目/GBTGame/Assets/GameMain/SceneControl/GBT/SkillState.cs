using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class SkillState : ISceneState
    {

        bool isFirst;
        public SkillState(SceneStateC c) : base(c)
        {
            this.StateName = "SkillState";
            isFirst = true;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFirst)
            {
                isFirst = false;
                EventManagerSystem.Instance.Add2(Data_EventName.SaveSkill_str, OnSaveSkill);
                EventManagerSystem.Instance.Add2(Data_EventName.BackMenu_str, OnBackMenu);
            }
            //开始时
            int lastKill = (int)m_Contorller.GetData("lastSkill");
            int defenseKill = (int)m_Contorller.GetData("defenseKill");
            int attackSkill = (int)m_Contorller.GetData("attackSkill");
            int attackSkillSpeed = (int)m_Contorller.GetData("attackSkillSpeed");
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_SkillForm,new SkillFormStruct(lastKill,  attackSkill, defenseKill, attackSkillSpeed));//打开UI

            
        }

        public override void StateUpdate()
        {

        }

        public override void StateEnd()
        {
            //结束时

            //EventManagerSystem.Instance.Delete2(Data_EventName.SaveSkill_str, OnSaveSkill);
            //EventManagerSystem.Instance.Delete2(Data_EventName.BackMenu_str, OnBackMenu);
        }



        private void OnSaveSkill(IEventArgs eventArgs)
        {
            SaveSkillEventArgs saveSkillEventArgs = (SaveSkillEventArgs)eventArgs;

            m_Contorller.SetData("lastSkill", saveSkillEventArgs.lastKill);
            m_Contorller.SetData("defenseKill", saveSkillEventArgs.defence);
            m_Contorller.SetData("attackSkill", saveSkillEventArgs.attack);
            m_Contorller.SetData("attackSkillSpeed", saveSkillEventArgs.attackSpeed);
        }

        private void OnBackMenu(IEventArgs eventArgs)
        {
            m_Contorller.SetState("MenuState");
        }
    }
}

