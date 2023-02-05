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
                EventManagerSystem.Instance.Add2(Data_EventName.OpenSkill_str, OpenSkill);
                EventManagerSystem.Instance.Add("ChangeSateToStart", ChangeStateToStartState);
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
            //FuncTime();
            //Time.deltaTime;
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {

        }

        

        void GameSucceed(IEventArgs eventArgs)
        {
            SoundSystem.Instance.StopAllEffect();
            GameSucceedEventArgs gameSucceedEventArgs = eventArgs as GameSucceedEventArgs;
            SoundSystem.Instance.PlayEffect("Switch");
            if (gameSucceedEventArgs.level==1)
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
                int maxId = 2001;
                int maxVal = 0;
                string path = "";
                foreach(var item in GGJDataManager.Instance.GameSucceedItemValMap)
                {
                    //Debug.Log(item.ToString());
                    if(item.Value>= maxVal)
                    {
                        maxId = item.Key;
                        path = GGJDataManager.Instance.GameSucceedMap[maxId];
                    }
                }
                Debug.Log(path);
                GGJDataManager.Instance.SucceedId = maxId;
                GGJDataManager.Instance.SucceedPath = path;

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
                UISystem.Instance.OpenUIForm(Data_UIFormID.key_GameSuccess);
            }
        }

        void GameFail(IEventArgs eventArgs)
        {
            SoundSystem.Instance.StopAllEffect();
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

        void OpenSkill(IEventArgs eventArgs)
        {
            if(GGJDataManager.Instance.functionType == EFunctionType.Pause)
            {
                if (GGJDataManager.Instance.Rect != null)
                {
                    foreach (var item in GGJDataManager.Instance.Rect.gameObject.GetComponentsInChildren<Transform>())
                    {
                        if (item != GGJDataManager.Instance.Rect)
                        {
                            item.gameObject.GetComponent<ToolItem>().Pause();
                        }
                            
                    }
                }
                if (GGJDataManager.Instance.Rect2 != null)
                {
                    foreach (var item in GGJDataManager.Instance.Rect2.gameObject.GetComponentsInChildren<Transform>())
                    {
                        if (item != GGJDataManager.Instance.Rect)
                        {
                            item.gameObject.GetComponent<ToolItem>().Pause();
                        }

                    }
                }
            }
            else if(GGJDataManager.Instance.functionType == EFunctionType.Refresh)
            {
                if (GGJDataManager.Instance.Rect != null)
                {
                    foreach (var item in GGJDataManager.Instance.Rect.gameObject.GetComponentsInChildren<Transform>())
                    {
                        if (item != GGJDataManager.Instance.Rect)
                            GameObject.Destroy(item.gameObject);
                    }
                }
                if (GGJDataManager.Instance.Rect2 != null)
                {
                    foreach (var item in GGJDataManager.Instance.Rect2.gameObject.GetComponentsInChildren<Transform>())
                    {
                        if (item != GGJDataManager.Instance.Rect)
                        {
                            item.gameObject.GetComponent<ToolItem>().Pause();
                        }

                    }
                }

                if (ToolForm != null)
                {
                    ToolForm.GetComponent<UIForm>().OnDestory();
                }
                if (GGJDataManager.Instance.level == 1)
                {
                    ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_1);
                }
                else if (GGJDataManager.Instance.level == 2)
                {
                    ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_2);
                }
                else if (GGJDataManager.Instance.level == 3)
                {
                    ToolForm = UISystem.Instance.OpenUIForm(Data_UIFormID.key_ToolForm_3);
                }
            }
            
            
        }

        void ChangeStateToStartState()
        {
            m_Contorller.SetState("StartState");
        }
    }
}

