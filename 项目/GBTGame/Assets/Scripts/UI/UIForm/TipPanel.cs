using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2023/2/5 14:30:51
public partial class TipPanel : UIForm
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
		m_btnClose.onClick.AddListener(OnBtnClose);
	}

	private void ReleaseEvent()
	{
		m_btnClose.onClick.RemoveListener(OnBtnClose);
	}

	private void OnBtnClose()
	{
		Debug.Log("asdasd");
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_TipPanel,this);//��UI
    }

}

