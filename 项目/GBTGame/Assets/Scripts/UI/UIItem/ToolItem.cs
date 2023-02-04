using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 20:02:55
public partial class ToolItem : UIItem
{
	ToolForm parent;
	public Vector3 position;

	float minX;
	float maxX;
	public bool isMove = false;

	bool isLeft = false;

	bool isStop = false;
	float isStopTime = 0f;


    Vector3 forward;
	float speed;

	RectTransform rectTransform;

	public EToolItemType toolItemType;
	public EFunctionType toolFuncitonType;
	int toolItemVal;

	public ToolSetting toolSetting;

	public Dictionary<int, EToolItemType> toolItemDic;
    public Dictionary<int, EFunctionType> functionItemDic;
    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		toolItemDic = new Dictionary<int, EToolItemType>();
		functionItemDic = new Dictionary<int, EFunctionType>();

        toolItemDic.Add(1001, EToolItemType.Oxygen);
        toolItemDic.Add(1002, EToolItemType.Oxygen);
        toolItemDic.Add(1003, EToolItemType.Water);
        toolItemDic.Add(1004, EToolItemType.Water);
        toolItemDic.Add(1005, EToolItemType.Fertilizer);
        toolItemDic.Add(1006, EToolItemType.Fertilizer);

        toolItemDic.Add(2001, EToolItemType.GinsengPeople);
        toolItemDic.Add(2002, EToolItemType.Frog);
        toolItemDic.Add(2003, EToolItemType.Meteor);
        toolItemDic.Add(2004, EToolItemType.DiamondsPig);
        toolItemDic.Add(2005, EToolItemType.DiamondsPig);
        toolItemDic.Add(2006, EToolItemType.Bird);
        toolItemDic.Add(2007, EToolItemType.Diamonds);
        toolItemDic.Add(2008, EToolItemType.Mushroom);
        toolItemDic.Add(2009, EToolItemType.Coconut);

        toolItemDic.Add(3001, EToolItemType.Function);
        toolItemDic.Add(3002, EToolItemType.Function);
        toolItemDic.Add(3003, EToolItemType.Function);
        toolItemDic.Add(3004, EToolItemType.Function);
        toolItemDic.Add(3005, EToolItemType.Function);

        functionItemDic.Add(3001, EFunctionType.Boomer);
        functionItemDic.Add(3002, EFunctionType.AddSpeed);
        functionItemDic.Add(3003, EFunctionType.Pause);
        functionItemDic.Add(3004, EFunctionType.Stop);
        functionItemDic.Add(3005, EFunctionType.Refresh);

        parent = uiForm as ToolForm;
        this.GetComponent<RectTransform>().SetParent(GGJDataManager.Instance.Rect);
        rectTransform = GetComponent<RectTransform>();
		speed = 80;
        forward = new Vector3(0, 0, 0);
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent();
		this.gameObject.SetActive(false);
		FuncToolItemVal();
    }

	public override void Update()
	{
		base.Update();
		if(isStop)
		{
			isStopTime += Time.deltaTime;
			if(isStopTime>1f)
			{
				isStop = false;

            }

        }
		if(isMove&&!isStop)
		{
            forward.x = Time.deltaTime* speed;

            if (rectTransform.localPosition.x > maxX)
			{
				isStop = true;
                isLeft = true;
            }
			if(rectTransform.localPosition.x < minX)
			{
				isStop = true;
                isLeft = false;

            }

			if(isLeft)
			{
                rectTransform.localPosition = rectTransform.localPosition - forward;
            }
			else
			{
                rectTransform.localPosition = rectTransform.localPosition + forward;
            }
        }
	}

	private void RegisterEvent()
	{
		
	}

	private void ReleaseEvent()
	{
		
	}

	public void SetLocation(Vector3 pos)
	{
        rectTransform.localPosition = pos;
		position = pos;
    }

	public void Move(float _minX,float _maxX,float _speed)
	{
		minX = _minX;
        maxX = _maxX;
		speed = _speed;
        isMove = true;
    }

	public void SetToolItemType(EToolItemType _toolItemType,int _toolItemVal)
	{
		toolItemType = _toolItemType;
		toolItemVal = _toolItemVal;
    }

	public void SetToolItemSetting(ToolSetting _toolSetting)
	{
		toolSetting = _toolSetting;
		if(toolSetting.speed!=0)
		{
			Move(rectTransform.localPosition.x - toolSetting.area / 2, rectTransform.localPosition.x + toolSetting.area / 2, toolSetting.speed);
        }
        SetToolItemType((EToolItemType)toolSetting.effectType, toolSetting.effectNum);
        toolItemType = toolItemDic[toolSetting.mainId];
		m_txtDes.text = toolSetting.mainId.ToString();
		if(toolItemType==EToolItemType.Function)
		{
			toolFuncitonType = functionItemDic[toolSetting.mainId];

        }
    }

	private void FuncToolItemVal()
	{
		Debug.Log(toolItemType);
		if(toolItemType!=EToolItemType.Function)
		{
            GGJDataManager.Instance.ToolItemValMap[toolItemType] += toolItemVal;
        }
	}
}

