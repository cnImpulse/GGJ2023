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
    public string soundPath;
}
//CreateTime：2023/2/3 20:58:45
public partial class ToolForm : UIForm
{
    List<Vector3> posList;
    List<Vector3> posList2;
    bool isCreate = false;
	float iconwidth = 90;

	int level;
	List<ToolSetting> ToolSettings1;
    List<ToolSetting> ToolSettings2;
    List<ToolSetting> ToolSettings3;

    int totalResources;
    int trigger;
    int goodsMax1;
    int goodsMax2;
    int goodsMax3;

    int currgoods1;
    int currgoods2;
    int currgoods3;

    float createCD;
    float createCDTime;

    int destoryNum;

    public Dictionary<EToolItemType, int> toolItemTypeDic;
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
        toolItemTypeDic = new Dictionary<EToolItemType, int>();

        toolItemTypeDic.Add(EToolItemType.Oxygen,1);
        toolItemTypeDic.Add(EToolItemType.Water,1);
        toolItemTypeDic.Add(EToolItemType.Fertilizer,1);

        toolItemTypeDic.Add(EToolItemType.GinsengPeople,2);
        toolItemTypeDic.Add(EToolItemType.Frog,2);
        toolItemTypeDic.Add(EToolItemType.Meteor,2);
        toolItemTypeDic.Add(EToolItemType.DiamondsPig,2);
        toolItemTypeDic.Add(EToolItemType.Bird,2);
        toolItemTypeDic.Add(EToolItemType.Diamonds,2);
        toolItemTypeDic.Add(EToolItemType.Mushroom,2);
        toolItemTypeDic.Add(EToolItemType.Coconut,2);

        toolItemTypeDic.Add(EToolItemType.Function,3);

        

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

        level = GGJDataManager.Instance.level;
        posList = new List<Vector3>();
        posList2 = new List<Vector3>();
        ToolSettings1 = new List<ToolSetting>();
        ToolSettings2= new List<ToolSetting>();
        ToolSettings3 = new List<ToolSetting>();

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
                        toolSetting.soundPath = temp.Attrs[14];
                        if (toolItemTypeDic[toolItemDic[j * 1000 + i]] == 1)
                        {
                            ToolSettings1.Add(toolSetting);
                        }
                        else if (toolItemTypeDic[toolItemDic[j * 1000 + i]] == 2)
                        {
                            ToolSettings2.Add(toolSetting);
                        }
                        else if (toolItemTypeDic[toolItemDic[j * 1000 + i]] == 3)
                        {
                            ToolSettings3.Add(toolSetting);
                        }
                    }
                }
            }
        }

        AttrList temp2 = AttrSystem.Instance.GetData("LevelTable", "10001") as AttrList;
        if(level == 2)
        {
            Debug.Log("isLevel2");
            temp2 = AttrSystem.Instance.GetData("LevelTable", "10002") as AttrList;
        }
        else if(level == 3)
        {
            Debug.Log("isLevel3");
            temp2 = AttrSystem.Instance.GetData("LevelTable", "10003") as AttrList;
        }

        totalResources = int.Parse(temp2.Attrs[4]);
        trigger = int.Parse(temp2.Attrs[5]);
        goodsMax1 = int.Parse(temp2.Attrs[6]);
        goodsMax2 = int.Parse(temp2.Attrs[7]);
        goodsMax3 = int.Parse(temp2.Attrs[8]);

        Debug.Log("totalResources    "+totalResources.ToString());

        Attr4<string, string, string, string> paramTable = AttrSystem.Instance.GetData("ParamTable", "4") as Attr4<string,string,string,string>;

        createCD = float.Parse(paramTable.c)/1000f;
        createCDTime = createCD;
        destoryNum = 0;

        currgoods1 = 0;
        currgoods2 = 0;
        currgoods3 = 0;

        CreateToolItems();
    }

	public override void Update()
	{
		base.Update();
        if(destoryNum>1 && createCDTime>= createCD)
        {
            int max = (totalResources - trigger) / 2;
            int res = (int)Mathf.Lerp(0, max, (float)destoryNum / (float)(totalResources - trigger));
            for(int i=0;i< res;i++)
            {
                destoryNum--;
                CreateItemBySetting(GetSetting());
            }
            
            createCDTime = 0f;
        }
        createCDTime += Time.deltaTime;
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
        
        //AttrList level1 = AttrSystem.Instance.GetData("LevelTable", "10001") as AttrList;
        if(GGJDataManager.Instance.level==2)
        {
            goodsMax1 *= 2;
            goodsMax2 *= 2;
            goodsMax3 *= 2;
            for (int i = 0; i < totalResources; i++)
            {
                CreateItemBySetting(GetSetting());
            }
            for (int i = 0; i < totalResources; i++)
            {
                CreateItemBySetting2(GetSetting());
            }
        }
        else
        {
            for (int i = 0; i < totalResources; i++)
            {
                CreateItemBySetting(GetSetting());
            }
        }
;       
    }

    private void OnDestoryItem(IEventArgs eventArgs)//删除item;
    {
        DestoryToolEventArgs destoryToolEventArgs = eventArgs as DestoryToolEventArgs;
        bool isUnder = destoryToolEventArgs.isUnder;
        var toolItem = destoryToolEventArgs.obj.GetComponent<ToolItem>();
        for (int i = 0; i < posList.Count; ++i)
        {
            if (posList[i] == toolItem.position)
            {
                posList.RemoveAt(i);
                break;
            }
        }
        if (toolItem == null)
        {
            return;
        }
        if (GGJDataManager.Instance.level==2)
        {
            toolItem.isUnder = isUnder;
        }
        if(toolItem.toolItemType==EToolItemType.Function)
        {
            GGJDataManager.Instance.functionType = toolItem.toolFuncitonType;
        }
        if(GGJDataManager.Instance.level != 2)
        {
            destoryNum++;
        }
        if (toolItemTypeDic[toolItem.toolItemType]==1)
        {
            currgoods1--;
        }
        else if(toolItemTypeDic[toolItem.toolItemType] == 2)
        {
            currgoods2--;
        }
        else if(toolItemTypeDic[toolItem.toolItemType] == 3)
        {
            currgoods3--;
        }
        if(toolItem.toolSetting.soundPath!="")
        {
            float volume = 0.7f;
            if(toolItem.toolItemType == EToolItemType.Oxygen|| toolItem.toolItemType == EToolItemType.Fertilizer)
            {
                volume = 1F;
            }
            SoundSystem.Instance.PlayEffect(toolItem.toolSetting.soundPath, volume);
        }
        UISystem.Instance.CloseUIItem(DataCs.Data_UIItemID.key_ToolItem, toolItem);
        if(GGJDataManager.Instance.level == 2 && isUnder)
        {
            ToolSetting tempsetting = toolItem.toolSetting;
            float radom = Random.Range(0, 1);
            if (radom <= 0.6)
            {
                CreateItemBySetting2(tempsetting);
                CreateItemBySetting2(tempsetting);
            }
            else
            {
                CreateItemBySetting2(tempsetting);
            }
        }
        
    }

    private void OnCrashItem(IEventArgs eventArgs)//删除item;
    {
        CrashToolEventArgs crashToolEventArgs = eventArgs as CrashToolEventArgs;
		var temp = crashToolEventArgs.obj.GetComponent<ToolItem>();
        if(temp)
        {
            temp.isMove = false;
        }
    }

    bool isArea(float width,Vector3 a,Vector3 b)
	{
		if(Mathf.Abs(a.x - b.x)< width&& Mathf.Abs(a.y - b.y) < width)
		{
			return true;
		}
		return false;
	}

    void CreateItemBySetting(ToolSetting tempsetting)
    {
        float x = GGJDataManager.Instance.Rect.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this, true) as ToolItem;
        Vector3 temp2 = Vector3.zero;// new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);

        for (int i = 0; i < 25; i++)
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
        temp.SetToolItemSetting(tempsetting);
    }

    void CreateItemBySetting2(ToolSetting tempsetting)
    {
        float x = GGJDataManager.Instance.Rect2.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect2.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this,false) as ToolItem;
        Vector3 temp2 = Vector3.zero;// new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);

        bool isrepeat = false;
        for (int i = 0; i < 25; i++)
        {
            isrepeat = false;
            temp2 = new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);
            for (int j = 0; j < posList2.Count; ++j)
            {
                if (isArea(width * 2, temp2, posList2[j]))
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
        if (GGJDataManager.Instance.level == 2)
        {
            Debug.Log(isrepeat ? "repeat" : "NoRepect");
            Debug.Log(temp2);
        }
        temp.SetLocation(temp2);
        posList2.Add(temp2);
        temp.SetToolItemSetting(tempsetting);
    }

    ToolSetting GetSetting()
    {
        float sum = 0;
        float subsum = 0;
        int index = 0;
        bool isOk = false;
        ToolSetting settings = ToolSettings1[0];

        if (GGJDataManager.Instance.level == 3 && GGJDataManager.Instance.specialNum < 3)
        {
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    sum += ToolSettings2[i].weight;
                }
            }
        }
        else
        {
            if (currgoods1 < goodsMax1)
            {
                for (int i = 0; i < ToolSettings1.Count; i++)
                {
                    sum += ToolSettings1[i].weight;
                }
            }
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    sum += ToolSettings2[i].weight;
                }
            }
            if (currgoods3 < goodsMax3)
            {
                for (int i = 0; i < ToolSettings3.Count; i++)
                {
                    sum += ToolSettings3[i].weight;
                }
            }
        }



        if (sum == 0)
        {
            Debug.Log("NoItem");
            return default;
        }

        float random = Random.Range(0, sum);

        if (GGJDataManager.Instance.level == 3 && GGJDataManager.Instance.specialNum < 3)
        {
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    subsum += ToolSettings2[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods2++;
                        settings = ToolSettings2[i];
                        isOk = true;
                        break;
                    }
                }
            }
        }
        else
        {
            if (currgoods1 < goodsMax1)
            {
                for (int i = 0; i < ToolSettings1.Count; i++)
                {
                    subsum += ToolSettings1[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods1++;
                        settings = ToolSettings1[i];
                        isOk = true;
                        break;
                    }
                }
            }
            if (!isOk && currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    subsum += ToolSettings2[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods2++;
                        settings = ToolSettings2[i];
                        isOk = true;
                        break;
                    }
                }
            }
            if (!isOk && currgoods3 < goodsMax3)
            {
                for (int i = 0; i < ToolSettings3.Count; i++)
                {
                    subsum += ToolSettings3[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods3++;
                        settings = ToolSettings3[i];
                        isOk = true;
                        break;
                    }
                }
            }
        }
        return settings;
    }
	void CreateItemByTable()
	{
        float sum = 0;
        float subsum = 0;
        int index = 0;
        bool isOk = false;
        ToolSetting settings = ToolSettings1[0];

        if (GGJDataManager.Instance.level == 3 && GGJDataManager.Instance.specialNum < 3)
        {
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    sum += ToolSettings2[i].weight;
                }
            }
        }
        else
        {
            if (currgoods1 < goodsMax1)
            {
                for (int i = 0; i < ToolSettings1.Count; i++)
                {
                    sum += ToolSettings1[i].weight;
                }
            }
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    sum += ToolSettings2[i].weight;
                }
            }
            if (currgoods3 < goodsMax3)
            {
                for (int i = 0; i < ToolSettings3.Count; i++)
                {
                    sum += ToolSettings3[i].weight;
                }
            }
        }

        

        if(sum==0)
        {
            Debug.Log("NoItem");
            return;
        }

        float random = Random.Range(0, sum);

        if (GGJDataManager.Instance.level == 3 && GGJDataManager.Instance.specialNum < 3)
        {
            if (currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    subsum += ToolSettings2[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods2++;
                        settings = ToolSettings2[i];
                        isOk = true;
                        break;
                    }
                }
            }
        }
        else
        {
            if (currgoods1 < goodsMax1)
            {
                for (int i = 0; i < ToolSettings1.Count; i++)
                {
                    subsum += ToolSettings1[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods1++;
                        settings = ToolSettings1[i];
                        isOk = true;
                        break;
                    }
                }
            }
            if (!isOk && currgoods2 < goodsMax2)
            {
                for (int i = 0; i < ToolSettings2.Count; i++)
                {
                    subsum += ToolSettings2[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods2++;
                        settings = ToolSettings2[i];
                        isOk = true;
                        break;
                    }
                }
            }
            if (!isOk && currgoods3 < goodsMax3)
            {
                for (int i = 0; i < ToolSettings3.Count; i++)
                {
                    subsum += ToolSettings3[i].weight;
                    if (random > subsum)
                    {
                        index++;
                    }
                    else
                    {
                        currgoods3++;
                        settings = ToolSettings3[i];
                        isOk = true;
                        break;
                    }
                }
            }
        }

        

        float x = GGJDataManager.Instance.Rect.sizeDelta.x;
        float y = GGJDataManager.Instance.Rect.sizeDelta.y;
        float width = iconwidth;

        var temp = UISystem.Instance.OpenUIItem(DataCs.Data_UIItemID.key_ToolItem, this) as ToolItem;
        Vector3 temp2 = Vector3.zero;// new Vector3(Random.Range(-(x - width) / 2, (x - width) / 2), Random.Range(-(y - width) / 2, (y - width) / 2), 0);
        bool isrepeat = false;
        for (int i = 0; i < 25; i++)
        {
            isrepeat = false;
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
        if(GGJDataManager.Instance.level==2)
        {
            Debug.Log(isrepeat?"repeat":"NoRepect");
            Debug.Log(temp2);
        }
        temp.SetLocation(temp2);
        posList.Add(temp2);
        temp.SetToolItemSetting(settings);

  
    }
}

