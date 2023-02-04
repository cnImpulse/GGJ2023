using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

public enum EToolItemType
{
	Oxygen,
    Fertilizer,
	Water,
    Diamonds,
    Bird,
    DiamondsPig,
	Function,
}
//CreateTime：2023/2/3 20:58:45
public partial class ToolForm : UIForm
{
    List<Vector3> posList;
    bool isCreate = false;
	List<float> itemLists;
	float iconwidth = 60;

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		/*GGJDataManager.Instance.Rect.localPosition = GGJDataManager.Instance.Rect.localPosition;
		GGJDataManager.Instance.Rect.sizeDelta = GGJDataManager.Instance.Rect.sizeDelta;*/

        posList = new List<Vector3>();
		itemLists = new List<float>();

		itemLists.Add(1f);
        itemLists.Add(1f);
        itemLists.Add(1f);
        itemLists.Add(1f);
        itemLists.Add(1f);
        itemLists.Add(1f);

        CreateToolItems();
    }

	public override void Update()
	{
		base.Update();
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		EventManagerSystem.Instance.Add2(Data_EventName.DestoryTool_str, OnDestoryItem);
		EventManagerSystem.Instance.Add2(Data_EventName.CrashTool_str, OnCrashItem);
	}

	private void ReleaseEvent()
	{
        EventManagerSystem.Instance.Delete2(Data_EventName.DestoryTool_str, OnDestoryItem);
        EventManagerSystem.Instance.Add2(Data_EventName.CrashTool_str, OnCrashItem);
    }

	void CreateToolItems()
	{
;       for (int i = 0; i < 20; i++)
        {
			CreateToolItem();
        }

        for (int i = 0; i < 3; i++)
        {
            CreateMoveItem();
        }
    }

	void CreateToolItem()
	{
		float x = GGJDataManager.Instance.Rect.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this) as ToolItem;
		Vector3 temp2 = Vector3.zero;// new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);
        
		for(int i=0;i<10;i++)
		{
			bool isrepeat = false;
            temp2 = new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);
            for (int j = 0; j < posList.Count; ++j)
            {
                if (isArea(width*2, temp2, posList[j]))
                {
					isrepeat = true;
                    break;
                }
            }
			if(!isrepeat)
			{
				break;
			}
        }
        temp.SetLocation(temp2);
		posList.Add(temp2);
    }

	void CreateMoveItem()
	{
        float x = GGJDataManager.Instance.Rect.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this) as ToolItem;
        var temp2 = new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);

        temp.SetLocation(temp2);
        posList.Add(temp2);
        temp.Move(-(x - width) / 2, (x - width) / 2,200);
    }

    private void OnDestoryItem(IEventArgs eventArgs)//删除item;
    {
        DestoryToolEventArgs destoryToolEventArgs = eventArgs as DestoryToolEventArgs;
		var toolItem = destoryToolEventArgs.obj.GetComponent<ToolItem>();

		for(int i=0;i< posList.Count;++i)
		{
			if(posList[i]== toolItem.position)
			{
				posList.RemoveAt(i);
				break;
			}

        }

		UISystem.Instance.CloseUIItem(DataCs.Data_UIItemID.key_ToolItem, toolItem);
    }

    private void OnCrashItem(IEventArgs eventArgs)//删除item;
    {
        CrashToolEventArgs crashToolEventArgs = eventArgs as CrashToolEventArgs;
		var temp = crashToolEventArgs.obj.GetComponent<ToolItem>();
        temp.isMove = false;
    }

    bool isArea(float width,Vector3 a,Vector3 b)
	{
		if(Mathf.Abs(a.x - b.x)< width&& Mathf.Abs(a.y - b.y) < width)
		{
			return true;
		}
		return false;
	}

	void SetToolItemTip(ToolItem item)
	{
		item.SetToolItemType(EToolItemType.Oxygen, 10);
		float sum = 0;
		for(int i=0;i< itemLists.Count;i++)
		{
			sum += itemLists[i];

        }
		int index = 0 ;
		float tempval = Random.Range(0, sum);
		float tempsum = 0;
		for(int i=0;i< itemLists.Count; i++)
		{
			//if()
		}

    }
}

