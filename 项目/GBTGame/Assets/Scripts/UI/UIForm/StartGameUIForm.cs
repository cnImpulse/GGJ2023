using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2022/11/1 15:28:46
public partial class StartGameUIForm : UIForm
{
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnStart.onClick.AddListener(OnBtnStart);
		m_btnExit.onClick.AddListener(OnBtnExit);
		m_btnDeveloper.onClick.AddListener(OnBtnDeveloper);
		m_btnHelper.onClick.AddListener(OnHelper);
	}

	private void ReleaseEvent()
	{
		m_btnStart.onClick.RemoveListener(OnBtnStart);
		m_btnExit.onClick.RemoveListener(OnBtnExit);
        m_btnDeveloper.onClick.RemoveListener(OnBtnDeveloper);
        m_btnHelper.onClick.RemoveListener(OnHelper);
    }

	private void OnBtnStart()
	{
        SoundSystem.Instance.PlayEffect(Data_AudioID.key_Click);
        EventManagerSystem.Instance.Invoke2(Data_EventName.StartGame_str, StartGameEventArgs.Create());//触发开始游戏
		UISystem.Instance.CloseUIForm(Data_UIFormID.key_StartGameForm, this);
    }
	private void OnBtnExit()
	{
        SoundSystem.Instance.PlayEffect(Data_AudioID.key_Click);
        EventManagerSystem.Instance.Invoke2(Data_EventName.ExitGame_str, ExitGameEventArgs.Create());//触发结束游戏
    }

	private void OnBtnDeveloper()
	{
        SoundSystem.Instance.PlayEffect(Data_AudioID.key_Click);
        EventManagerSystem.Instance.Invoke2(Data_EventName.Developer_str, DeveloperEventArgs.Create());//打开开发者界面
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_StartGameForm, this);
    }

	private void OnHelper()
	{
        SoundSystem.Instance.PlayEffect(Data_AudioID.key_Click);
        //UISystem.Instance.OpenUIForm(Data_UIFormID.key_HelperForm);
	}
}

