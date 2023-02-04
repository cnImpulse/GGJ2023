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

        GameObject HandleForm;
        GameObject ToolForm;
        GameObject HUDForm;
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
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.GameSucceed_str, GameSucceed);
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.GameFail_str, GameFail);
            }
            /*SkillAdditionSystem.CreateInstance(0, 0, 0);
            
            EventManagerSystem.Instance.Add2(DataCs.Data_EventName.KillMonster_str, KillMonster);
            Enity1 = m_Contorller.GetData("Enity1") as GameObject;
            Enity1?.SetActive(true);*/

            //HpBarCanvas = m_Contorller.GetData("HpBarCanvas") as GameObject;

            HandleForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm_1);
            ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_1);
            HUDForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HUDForm);

            /*UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm_2);
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_2);

            UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm_3);
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_3);*/

            //UISystem.Instance.OpenUIForm(Data_UIFormID.key_GameFailForm);
        }

        public override void StateUpdate()
        {
            FuncTime();
            //Time.deltaTime;
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {

        }

        void FuncTime()
        {
            if(GGJDataManager.Instance.currTime-Time.deltaTime <=0)
            {
                GGJDataManager.Instance.currTime = 0f;

                if(GGJDataManager.Instance.TestSucceed())
                {
                    Debug.Log("Test1");
                    EventManagerSystem.Instance.Invoke2(DataCs.Data_EventName.GameSucceed_str, new GameSucceedEventArgs(GGJDataManager.Instance.level, (int)ESucceedType.Normal));
                    GGJDataManager.Instance.level++;
                    GGJDataManager.Instance.InitTime();
                }
                else
                {
                    Debug.Log("Test2");
                }
            }
            else
            {
                GGJDataManager.Instance.currTime -= Time.deltaTime;
            }
             //= Time.deltaTime;
        }

        void GameSucceed(IEventArgs eventArgs)
        {
            GameSucceedEventArgs gameSucceedEventArgs = eventArgs as GameSucceedEventArgs;
            if(gameSucceedEventArgs.level==1)
            {
                if(HandleForm!=null)
                {
                    HandleForm.GetComponent<UIForm>().OnDestory();
                }
                if (ToolForm != null)
                {
                    ToolForm.GetComponent<UIForm>().OnDestory();
                }
                if (HUDForm != null)
                {
                    HUDForm.GetComponent<UIForm>().OnDestory();
                }
                HandleForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm_2);
                ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_2);
                HUDForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HUDForm);
            }
            else if(gameSucceedEventArgs.level==2)
            {
                if (HandleForm != null)
                {
                    HandleForm.GetComponent<UIForm>().OnDestory();
                }
                if (ToolForm != null)
                {
                    ToolForm.GetComponent<UIForm>().OnDestory();
                }
                if (HUDForm != null)
                {
                    HUDForm.GetComponent<UIForm>().OnDestory();
                }
                HandleForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HandleForm_3);
                ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_3);
                HUDForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_HUDForm);
            }
            else
            {
                if (HandleForm != null)
                {
                    HandleForm.GetComponent<UIForm>().OnDestory();
                }
                if (ToolForm != null)
                {
                    ToolForm.GetComponent<UIForm>().OnDestory();
                }
                if (HUDForm != null)
                {
                    HUDForm.GetComponent<UIForm>().OnDestory();
                }
                Debug.Log(gameSucceedEventArgs.index);
                //UISystem.Instance.OpenUIForm(Data_UIFormID.key_);
            }
        }

        void GameFail(IEventArgs eventArgs)
        {
            if (HandleForm != null)
            {
                HandleForm.GetComponent<UIForm>().OnDestory();
            }
            if (ToolForm != null)
            {
                ToolForm.GetComponent<UIForm>().OnDestory();
            }
            if (HUDForm != null)
            {
                HUDForm.GetComponent<UIForm>().OnDestory();
            }
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_GameFailForm);
        }
    }
}

