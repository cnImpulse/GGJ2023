using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2022/11/5 10:30:12
public partial class MenuForm : UIForm
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
		m_btnLevel1.onClick.AddListener(OnBtnLevel1);
		m_btnLevel2.onClick.AddListener(OnBtnLevel2);
		m_btnLevel3.onClick.AddListener(OnBtnLevel3);
		m_btnBack.onClick.AddListener(OnBtnBack);
		m_btnSkillTree.onClick.AddListener(OnBtnSkillTree);
	}

	private void ReleaseEvent()
	{
		m_btnLevel1.onClick.RemoveListener(OnBtnLevel1);
		m_btnLevel2.onClick.RemoveListener(OnBtnLevel2);
		m_btnLevel3.onClick.RemoveListener(OnBtnLevel3);
		m_btnBack.onClick.RemoveListener(OnBtnBack);
		m_btnSkillTree.onClick.RemoveListener(OnBtnSkillTree);
	}

	private void OnBtnLevel1()
	{
		EventManagerSystem.Instance.Invoke2(Data_EventName.OpenLevel1_str, OpenLevel1EventArgs.Create());
		UISystem.Instance.CloseUIForm(Data_UIFormID.key_MenuForm, this);
	}
	private void OnBtnLevel2()
	{
        EventManagerSystem.Instance.Invoke2(Data_EventName.OpenLevel2_str, OpenLevel2EventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_MenuForm, this);
    }
	private void OnBtnLevel3()
	{
        EventManagerSystem.Instance.Invoke2(Data_EventName.OpenLevel3_str, OpenLevel3EventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_MenuForm, this);
    }
	private void OnBtnBack()
	{
        EventManagerSystem.Instance.Invoke2(Data_EventName.BackStartGame_str, BackStartGameEventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_MenuForm, this);
    }
	private void OnBtnSkillTree()
	{
		EventManagerSystem.Instance.Invoke2(Data_EventName.OpenSkill_str, OpenSkillEventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_MenuForm, this);
    }

}

