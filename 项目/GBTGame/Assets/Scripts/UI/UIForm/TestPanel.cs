using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 19:06:27
public partial class TestPanel : UIForm
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
		m_btnOK.onClick.AddListener(OnBtnOK);
	}

	private void ReleaseEvent()
	{
		m_btnOK.onClick.RemoveListener(OnBtnOK);
	}

	private void OnBtnOK()
	{
		int a;
	}

}

