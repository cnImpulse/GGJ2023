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

    float LimOxygen;
    float LimMaxFertilizer;
    float LimMaxWater;

    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

        if(GGJDataManager.Instance.level==1)
        {
            AttrList temp = AttrSystem.Instance.GetData("LevelTable", "10001") as AttrList;
            LimOxygen = int.Parse(temp.Attrs[1]);
            LimMaxWater = int.Parse(temp.Attrs[2]);
            LimMaxFertilizer = int.Parse(temp.Attrs[3]);
        }
        else if(GGJDataManager.Instance.level==2)
        {
            AttrList temp = AttrSystem.Instance.GetData("LevelTable", "10002") as AttrList;
            LimOxygen = int.Parse(temp.Attrs[1]);
            LimMaxWater = int.Parse(temp.Attrs[2]);
            LimMaxFertilizer = int.Parse(temp.Attrs[3]);
        }
        else if(GGJDataManager.Instance.level==3)
        {
            AttrList temp = AttrSystem.Instance.GetData("LevelTable", "10003") as AttrList;
            LimOxygen = int.Parse(temp.Attrs[1]);
            LimMaxWater = int.Parse(temp.Attrs[2]);
            LimMaxFertilizer = int.Parse(temp.Attrs[3]);
        }
        SetLimImg();

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
		m_scrollbarOxygen.size = GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen] / MaxOxygen;
		m_scrollbarFertilizer.size = GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer] / MaxFertilizer;
		m_scrollbarWater.size = GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water] / MaxWater;
        m_rectLevelDes.GetComponent<TMPro.TextMeshProUGUI>().text = GGJDataManager.Instance.level.ToString();
        FuncFunctionType();
        FunctionTime();
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

	public void FuncFunctionType()
	{
		switch(GGJDataManager.Instance.functionType)
		{
			case EFunctionType.Null:
				{
					m_imgFuncAddSpeed.gameObject.SetActive(false) ;
                    m_imgFuncBoom.gameObject.SetActive(false);
                    m_imgFuncimg.gameObject.SetActive(true);
                    m_imgFunciStop.gameObject.SetActive(false);
                    m_imgFuncPause.gameObject.SetActive(false);
                    m_txtFuncDes.text = "Null";
                    break;
				}
            case EFunctionType.Boomer:
                {
                    m_imgFuncAddSpeed.gameObject.SetActive(false);
                    m_imgFuncBoom.gameObject.SetActive(true);
                    m_imgFuncimg.gameObject.SetActive(false);
                    m_imgFunciStop.gameObject.SetActive(false);
                    m_imgFuncPause.gameObject.SetActive(false);
                    m_txtFuncDes.text = "Boomer";
                    break;
                }
            case EFunctionType.Stop:
                {
                    m_imgFuncAddSpeed.gameObject.SetActive(false);
                    m_imgFuncBoom.gameObject.SetActive(false);
                    m_imgFuncimg.gameObject.SetActive(false);
                    m_imgFunciStop.gameObject.SetActive(true);
                    m_imgFuncPause.gameObject.SetActive(false);
                    m_txtFuncDes.text = "Stop";
                    break;
                }
            case EFunctionType.AddSpeed:
                {
                    m_imgFuncAddSpeed.gameObject.SetActive(true);
                    m_imgFuncBoom.gameObject.SetActive(false);
                    m_imgFuncimg.gameObject.SetActive(false);
                    m_imgFunciStop.gameObject.SetActive(false);
                    m_imgFuncPause.gameObject.SetActive(false);
                    m_txtFuncDes.text = "AddSpeed";
                    break;
                }
            case EFunctionType.Pause:
                {
                    m_imgFuncAddSpeed.gameObject.SetActive(false);
                    m_imgFuncBoom.gameObject.SetActive(false);
                    m_imgFuncimg.gameObject.SetActive(false);
                    m_imgFunciStop.gameObject.SetActive(false);
                    m_imgFuncPause.gameObject.SetActive(true);
                    m_txtFuncDes.text = "Pause";
                    break;
                }
        }
	}

    public void FunctionTime()
    {
        float xiaoshu = GGJDataManager.Instance.currTime - Mathf.Floor(GGJDataManager.Instance.currTime);
        float zhengshu = (int)GGJDataManager.Instance.currTime;

        m_txtFen.text = zhengshu >= 10 ? zhengshu.ToString() : "0" + zhengshu.ToString();
        var temp = ((int)(xiaoshu * 100));
        m_txtSec.text = temp >= 10 ? temp.ToString() : "0" + temp.ToString();
    }

    public void SetLimImg()
    {
        m_imgFerLim.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-160 + 320 * LimMaxFertilizer / 100, 0, 0);
        m_imgOxyLim.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-160 + 320 * LimMaxWater / 100, 0, 0);
        m_imgWaterLim.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-160 + 320 * LimOxygen / 100, 0, 0);
    }
}

