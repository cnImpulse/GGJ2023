using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/4 0:00:46
public partial class HUDForm : UIForm
{
	float MaxOxygen;
    float MaxFertilizer;
    float MaxWater;

    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		MaxOxygen = 100;
		MaxFertilizer = 100;
		MaxWater = 100;
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	public override void Update()
	{
		base.Update();
		m_scrollbarOxygen.size = GGJDataManager.Instance.Oxygen/ MaxOxygen;
		m_scrollbarFertilizer.size = GGJDataManager.Instance.Fertilizer / MaxFertilizer;
		m_scrollbarWater.size = GGJDataManager.Instance.Water / MaxWater;

    }

	private void RegisterEvent()
	{
		m_btnFunc.onClick.AddListener(OnBtnFunc);
	}

	private void ReleaseEvent()
	{
		m_btnFunc.onClick.RemoveListener(OnBtnFunc);
	}

	private void OnBtnFunc()
	{
		
	}

}

