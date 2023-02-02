using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2022/11/6 11:19:28
public partial class HelperForm : UIForm
{

	RectTransform[] rectTransforms;

	int curr_index;
	public override void Awake()
	{
		base.Awake();
		InitComponent();

        rectTransforms = new RectTransform[8] {
			m_rect0,m_rect1, m_rect2 , m_rect3 , m_rect4 , m_rect5 , m_rect6 ,m_rect7
        };


    }

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		curr_index = 0;

        for (int i = 0; i < rectTransforms.Length; i++)
		{
			rectTransforms[i].gameObject.SetActive(false);
		}

		rectTransforms[0].gameObject.SetActive(true);

	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnClose.onClick.AddListener(OnBtnClose);
		m_btnUp.onClick.AddListener(OnBtnUp);
		m_btnDown.onClick.AddListener(OnBtnDown);
	}

	private void ReleaseEvent()
	{
		m_btnClose.onClick.RemoveListener(OnBtnClose);
        m_btnUp.onClick.RemoveListener(OnBtnUp);
        m_btnDown.onClick.RemoveListener(OnBtnDown);
    }

	private void OnBtnClose()
	{
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_HelperForm, this);
    }

	private void OnBtnUp()
	{
        if (curr_index <= 0 || curr_index >= rectTransforms.Length)
        {
            return;
        }
        curr_index--;

        for (int i = 0; i < rectTransforms.Length; i++)
        {
            rectTransforms[i].gameObject.SetActive(false);
        }

        rectTransforms[curr_index].gameObject.SetActive(true);
    }

	private void OnBtnDown()
	{
        if (curr_index < 0 || curr_index >= rectTransforms.Length - 1)
        {
            return;
        }
        curr_index++;

        for (int i = 0; i < rectTransforms.Length; i++)
        {
            rectTransforms[i].gameObject.SetActive(false);
        }

        rectTransforms[curr_index].gameObject.SetActive(true);
    }

}

