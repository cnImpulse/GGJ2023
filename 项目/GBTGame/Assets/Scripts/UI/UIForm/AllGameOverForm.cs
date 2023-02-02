using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2022/11/6 16:36:11
public partial class AllGameOverForm : UIForm
{
    float curr_time;
    float time;

    string des;
    int index;
    public override void Awake()
    {
        base.Awake();
        InitComponent();
    }

    public override void OnOpen(System.Object obj)
    {
        base.OnOpen(obj);
        RegisterEvent();
        curr_time = 0f;
        time = 0.1f;
        index = 0;
        des = "你的决心、力量和勇气都会被EMPYREAN的那位审视\n在冰与火的纷争中\n足够炽热的灵魂才会得到那位的赏识\n炽热的火终将融化臻冰\n而这股烈火必将守护我们珍视的一切\n永不熄灭……";
        m_txtDes.text = "";
    }

    public override void OnClose()
    {
        base.OnClose();
        ReleaseEvent();
    }

    public override void Update()
    {
        base.Update();
        curr_time += Time.deltaTime;
        if (curr_time >= time)
        {
            curr_time = 0f;
            if (index < des.Length)
            {
                m_txtDes.text = des.Substring(0, index);
            }
            else
            {
                if (index - des.Length > 30)
                {
                    OnOver();

                }
            }

            index++;
        }
    }

    private void RegisterEvent()
    {

    }

    private void ReleaseEvent()
    {

    }

    private void OnOver()
    {
        EventManagerSystem.Instance.Invoke2(Data_EventName.Developer_str, DeveloperEventArgs.Create());//打开开发者界面
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_AllGameOverForm, this);
    }


}

