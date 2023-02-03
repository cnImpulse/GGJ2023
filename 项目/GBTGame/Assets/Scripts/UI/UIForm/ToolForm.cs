using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2023/2/3 20:58:45
public partial class ToolForm : UIForm
{
    List<Vector3> posList;
    bool isCreate = false;

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		posList = new List<Vector3>();

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
	}

	private void ReleaseEvent()
	{
        
    }

	void CreateToolItems()
	{
;       for (int i = 0; i < 10; i++)
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
		float x = m_rectPanel.sizeDelta.x;
        float y = m_rectPanel.sizeDelta.y;
        float width = 100;

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
        float x = m_rectPanel.sizeDelta.x;
        float y = m_rectPanel.sizeDelta.y;
        float width = 100;

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

	bool isArea(float width,Vector3 a,Vector3 b)
	{
		if(Mathf.Abs(a.x - b.x)< width&& Mathf.Abs(a.y - b.y) < width)
		{
			return true;
		}
		return false;
	}
}

