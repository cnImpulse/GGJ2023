using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;
using static Unity.Burst.Intrinsics.X86.Avx;

public enum EToolItemType
{
	Oxygen,
    Fertilizer,
	Water,
    Diamonds,
    Bird,
    DiamondsPig,
    Mushroom,
    GinsengPeople,
    Coconut,
    Frog,
    Meteor,
    Function,
}

public struct ToolSetting
{
    public int mainId;
	public string iconPath;
    public float weight;
    public int effectType;
    public int effectNum;
    public float speed;
    public float area;
    public float retract;
}
//CreateTime：2023/2/3 20:58:45
public partial class ToolForm : UIForm
{
    List<Vector3> posList;
    bool isCreate = false;
	float iconwidth = 60;

	int level;
	List<ToolSetting> ToolSettings;



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
		level = 1;
        posList = new List<Vector3>();
		ToolSettings = new List<ToolSetting>();

        for (int j = 1; j < 4; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                AttrList temp = AttrSystem.Instance.GetData("ToolTable", (j*1000+i).ToString()) as AttrList;
                if (temp != null)
                {
					if (temp.Attrs[6].IndexOf((10000+level).ToString())!=-1)
					{
                        ToolSetting toolSetting = new ToolSetting();
                        toolSetting.mainId = j * 1000 + i;
                        toolSetting.iconPath = temp.Attrs[10];
						toolSetting.weight = float.Parse(temp.Attrs[6 + level]);
						toolSetting.effectType = int.Parse(temp.Attrs[11]);
						toolSetting.effectNum = int.Parse(temp.Attrs[12]);
						toolSetting.speed = float.Parse(temp.Attrs[3]);
						toolSetting.area = float.Parse(temp.Attrs[4]);
                        toolSetting.retract = float.Parse(temp.Attrs[5]);
                        ToolSettings.Add(toolSetting);
                    }
                }
            }
        }

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
            CreateItemByTable();
			//CreateToolItem();
        }

        /*for (int i = 0; i < 3; i++)
        {
            CreateMoveItem();
        }*/
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

	void CreateItemByTable()
	{
		float sum = 0;
		for(int i=0;i< ToolSettings.Count;i++)
		{
			sum += ToolSettings[i].weight;

        }

		float subsum = 0;
		int index = 0;

		float random = Random.Range(0, sum);
        for (int i = 0; i < ToolSettings.Count; i++)
        {
            subsum += ToolSettings[i].weight;
			if(random>subsum)
			{
                index++;
            }
			else
			{
				break;
			}
        }

        float x = GGJDataManager.Instance.Rect.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this) as ToolItem;
        Vector3 temp2 = Vector3.zero;// new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);

        for (int i = 0; i < 10; i++)
        {
            bool isrepeat = false;
            temp2 = new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);
            for (int j = 0; j < posList.Count; ++j)
            {
                if (isArea(width * 2, temp2, posList[j]))
                {
                    isrepeat = true;
                    break;
                }
            }
            if (!isrepeat)
            {
                break;
            }
        }
        temp.SetLocation(temp2);
        posList.Add(temp2);
        temp.SetToolItemSetting(ToolSettings[index]);
    }
}

