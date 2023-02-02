using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

public class GameOverStruct
{
	public string des;
	public bool isGameOver;
	public int level;
	public GameOverStruct(string des, bool isGameOver, int level)
	{
		this.des = des;
		this.isGameOver = isGameOver;
		this.level = level;
	}
}

//CreateTime：2022/11/5 10:42:13
public partial class GameOverForm : UIForm
{
	public int level;
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

        GameOverStruct temp = (GameOverStruct)obj;
		m_txtDeadDic.text = temp.des;
		level = temp.level;

        if (temp.isGameOver)
		{
			m_btnNext.gameObject.SetActive(false);
			m_btnReTry.gameObject.SetActive(true);
        }
		else if(temp.level < 2)
		{
            m_btnNext.gameObject.SetActive(true);
            m_btnReTry.gameObject.SetActive(false);
		}
		else
		{
            m_btnNext.gameObject.SetActive(false);
            m_btnReTry.gameObject.SetActive(true);
        }
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnOK.onClick.AddListener(OnBtnOK);
        m_btnNext.onClick.AddListener(OnBtnNext);
        m_btnReTry.onClick.AddListener(OnBtnReTry);

        //m_btnDeadDic.onClick.AddListener(OnBtnDeadDic);
    }

	private void ReleaseEvent()
	{
		m_btnOK.onClick.RemoveListener(OnBtnOK);
        m_btnNext.onClick.RemoveListener(OnBtnNext);
        m_btnReTry.onClick.RemoveListener(OnBtnReTry);
        //m_btnDeadDic.onClick.RemoveListener(OnBtnDeadDic);
    }

	private void OnBtnOK()
	{
        EventManagerSystem.Instance.Invoke2(Data_EventName.BackMenu_str, BackMenuEventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_GameOverForm, this);
    }

    private void OnBtnNext()
    {
        EventManagerSystem.Instance.Invoke2(Data_EventName.NextLevel_str, NextLevelEventArgs.Create(level+1));
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_GameOverForm, this);
    }

    private void OnBtnReTry()
    {
        EventManagerSystem.Instance.Invoke2(Data_EventName.NextLevel_str, NextLevelEventArgs.Create(level));
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_GameOverForm, this);
    }
}

