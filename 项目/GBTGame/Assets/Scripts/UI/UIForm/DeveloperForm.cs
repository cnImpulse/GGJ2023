using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DG.Tweening;
using DataCs;

//CreateTime：2022/11/1 16:22:51
public partial class DeveloperForm : UIForm
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

		m_btnBack.gameObject.SetActive(false);
		m_txtIntroduce.rectTransform.anchoredPosition = new Vector2(0, m_txtIntroduce.rectTransform.sizeDelta.y*1.6f);
		m_txtIntroduce.rectTransform.DOLocalMove(new Vector2(0, 0), 10f);
        Sequence seq = DOTween.Sequence();
		seq.AppendCallback(() =>
		{
            m_btnBack.gameObject.SetActive(true);
        })
		.SetDelay(10.5f);


    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnBack.onClick.AddListener(OnBtnBack);
	}

	private void ReleaseEvent()
	{
		m_btnBack.onClick.RemoveListener(OnBtnBack);
	}

	private void OnBtnBack()
	{
        EventManagerSystem.Instance.Invoke2(Data_EventName.BackStartGame_str, BackStartGameEventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_DeveloperForm, this);
    }

}

