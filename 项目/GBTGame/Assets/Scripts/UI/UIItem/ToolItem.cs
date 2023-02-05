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

	bool isPause = false;
	float isPauseTime = 3f;


    Vector3 forward;
	float speed;

	RectTransform rectTransform;

	public EToolItemType toolItemType;
	public EFunctionType toolFuncitonType;
	int toolItemVal;

	public ToolSetting toolSetting;

	public bool isUnder = false;

	
    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		bool isUnder = true;

        if (obj!=null)
		{
            isUnder = (bool)obj;
        }

        parent = uiForm as ToolForm;
		
		if(GGJDataManager.Instance.level==2&& !isUnder)
		{
            this.GetComponent<RectTransform>().SetParent(GGJDataManager.Instance.Rect2);
        }
		else
		{
            this.GetComponent<RectTransform>().SetParent(GGJDataManager.Instance.Rect);
        }
        
        rectTransform = GetComponent<RectTransform>();
		speed = 80;
        forward = new Vector3(0, 0, 0);
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent();
		this.gameObject.SetActive(false);
		if(GGJDataManager.Instance.level!=2 || isUnder == false)
		{
            FuncToolItemVal();
        }
		
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
        if (isPause)
        {
            isPauseTime += Time.deltaTime;
            if (isPauseTime > 3f)
            {
                isPause = false;
            }
        }
        if (isMove&&!isStop&&!isPause)
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
		if (toolSetting.speed != 0)
		{
			Move(rectTransform.localPosition.x - toolSetting.area, rectTransform.localPosition.x + toolSetting.area, toolSetting.speed);
		}
		SetToolItemType((EToolItemType)toolSetting.effectType, toolSetting.effectNum);
		toolItemType = parent.toolItemDic[toolSetting.mainId];
		m_txtDes.text = toolSetting.mainId.ToString();

		


        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + toolSetting.iconPath);
		this.gameObject.GetComponent<Image>().SetNativeSize();
		if (toolSetting.mainId == 1001 || toolSetting.mainId == 1003 || toolSetting.mainId == 1005)
		{
			this.gameObject.GetComponent<CircleCollider2D>().radius = 30;
		}
		else
		{
			this.gameObject.GetComponent<CircleCollider2D>().radius = 18;
		}



		if (toolItemType == EToolItemType.Function)
		{
			toolFuncitonType = parent.functionItemDic[toolSetting.mainId];
		}
		if (parent.toolItemTypeDic[toolItemType] == 2)
		{
			GGJDataManager.Instance.specialNum++;
		}
    }

	private void FuncToolItemVal()
	{
		if(toolItemType!=EToolItemType.Function)
		{
			if (toolSetting.mainId > 2000 && toolSetting.mainId < 3000)
			{
                GGJDataManager.Instance.GameSucceedItemValMap[toolSetting.mainId] += toolItemVal;
            }
            GGJDataManager.Instance.ToolItemValMap[toolItemType] += toolItemVal;
        }
	}

	public void Pause()
	{
		isPauseTime = 0f;
		isPause = true;

    }
}

