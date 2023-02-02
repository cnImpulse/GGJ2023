using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 11:08:05
public partial class StartGameForm : UIForm
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
		m_btnDeveloper.onClick.AddListener(OnBtnDeveloper);
		m_btnExit.onClick.AddListener(OnBtnExit);
		m_btnHelper.onClick.AddListener(OnBtnHelper);
	}

	private void ReleaseEvent()
	{
		m_btnStart.onClick.RemoveListener(OnBtnStart);
		m_btnDeveloper.onClick.RemoveListener(OnBtnDeveloper);
		m_btnExit.onClick.RemoveListener(OnBtnExit);
		m_btnHelper.onClick.RemoveListener(OnBtnHelper);
	}

	private void OnBtnStart()
	{
		
	}
	private void OnBtnDeveloper()
	{
		
	}
	private void OnBtnExit()
	{
		
	}
	private void OnBtnHelper()
	{
		
	}

}

