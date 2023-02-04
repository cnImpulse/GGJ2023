using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using ProtoBuf.Meta;

//CreateTime：2023/2/4 0:00:46
public partial class HUDForm : UIForm
{
	float MaxOxygen;
    float MaxFertilizer;
    float MaxWater;

    float LimOxygen;
    float LimMaxFertilizer;
    float LimMaxWater;

    float deadTime;
    float deadTimeCurr;

    int OxygenSub;
    int FertilizerSub;
    int WaterSub;

    float subTime;
    float currSubTime;
    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
        deadTime = 3f;
        deadTimeCurr = 0f;
        subTime = 1f;
        currSubTime = 0f;
        Attr4<string, string, string, string> paramTable1 = AttrSystem.Instance.GetData("ParamTable", "9") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable2 = AttrSystem.Instance.GetData("ParamTable", "10") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable3 = AttrSystem.Instance.GetData("ParamTable", "11") as Attr4<string, string, string, string>;

        Attr4<string, string, string, string> paramTable12 = AttrSystem.Instance.GetData("ParamTable", "12") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable13 = AttrSystem.Instance.GetData("ParamTable", "13") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable14 = AttrSystem.Instance.GetData("ParamTable", "14") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable15 = AttrSystem.Instance.GetData("ParamTable", "15") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable16 = AttrSystem.Instance.GetData("ParamTable", "16") as Attr4<string, string, string, string>;
        Attr4<string, string, string, string> paramTable17 = AttrSystem.Instance.GetData("ParamTable", "17") as Attr4<string, string, string, string>;

        GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen] = Random.Range(int.Parse(paramTable12.c), int.Parse(paramTable13.c));
        GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water] = Random.Range(int.Parse(paramTable14.c), int.Parse(paramTable15.c));
        GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer] = Random.Range(int.Parse(paramTable16.c), int.Parse(paramTable17.c));

        Debug.Log(GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen]);
        Debug.Log(GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water]);
        Debug.Log(GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer]);

        OxygenSub = 3;// int.Parse(paramTable1.c);
        WaterSub = 3; //int.Parse(paramTable2.c);
        FertilizerSub = 3; //int.Parse(paramTable3.c);

        if (GGJDataManager.Instance.level==1)
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
        
        currSubTime += Time.deltaTime;
        if (GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen] >= LimOxygen &&
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water] >= LimMaxWater &&
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer] >= LimMaxFertilizer)
        {
            deadTimeCurr += Time.deltaTime;
        }

        if (currSubTime>=subTime)
        {
            Debug.Log(OxygenSub);
            Debug.Log(FertilizerSub);
            Debug.Log(WaterSub);
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen] -= OxygenSub;
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer] -= FertilizerSub;
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water] -= WaterSub;
            currSubTime = 0f;
        }

        if (GGJDataManager.Instance.ToolItemValMap[EToolItemType.Oxygen] <=0 ||
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Water] <= 0 ||
            GGJDataManager.Instance.ToolItemValMap[EToolItemType.Fertilizer] <= 0|| 
            deadTimeCurr>=deadTime)
        {
            EventManagerSystem.Instance.Invoke2(DataCs.Data_EventName.GameFail_str, new GameFailEventArgs());
        }


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

