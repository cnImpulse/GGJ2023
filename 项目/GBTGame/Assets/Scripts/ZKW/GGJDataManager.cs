using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameFrameWork
{
    public enum EFunctionType
    {
        Null,
        Boomer,
        AddSpeed,
        Stop,
        Pause,
        Refresh
    }

    public enum ESucceedType
    {
        Normal
    }
    public class GGJDataManager
    {
        private GGJDataManager() { }
        //单例模式
        private static GGJDataManager instance = new GGJDataManager();
        public static GGJDataManager Instance
        {
            get { return instance; }
        }

        public void Init()
        {
            ToolItemValMap = new Dictionary<EToolItemType, int>();
            for (int i = (int)EToolItemType.Oxygen; i < 11; i++)
            {
                ToolItemValMap.Add((EToolItemType)i, 0);
            }

            ToolItemValMap[EToolItemType.Oxygen] = 50;
            ToolItemValMap[EToolItemType.Fertilizer] = 25;
            ToolItemValMap[EToolItemType.Water] = 30;
            functionType = 0;
            InitTime();
            level = 1;
            specialNum = 0;
            isPause = false;
        }
        public bool TestSucceed()
        {
            
            if(ToolItemValMap[EToolItemType.Oxygen] <= 0 && ToolItemValMap[EToolItemType.Oxygen] >= 100)
            {
                return false;
            }

            if (ToolItemValMap[EToolItemType.Fertilizer] <= 0 && ToolItemValMap[EToolItemType.Fertilizer] >= 100)
            {
                return false;
            }

            if (ToolItemValMap[EToolItemType.Water] <= 0 && ToolItemValMap[EToolItemType.Water] >= 100)
            {
                return false;
            }

            return true;
        }

        public void InitTime()
        {
            currTime = 20f;
        }

        public EFunctionType functionType;
        public UnityEngine.RectTransform Rect;
        public UnityEngine.RectTransform Rect2;

        public float currTime;
        public int level;

        public Dictionary<EToolItemType,int> ToolItemValMap;

        public int specialNum;

        public bool isPause;
    }
}
