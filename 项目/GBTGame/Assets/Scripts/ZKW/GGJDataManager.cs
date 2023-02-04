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
        Pause
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
            Oxygen = 50;
            Fertilizer = 25;
            Water = 30;
            Diamonds = 0;
            Bird = 0;
            DiamondsPig = 0;
            functionType = 0;
            currTime = 60;
            level = 1;
        }
        public bool TestSucceed()
        {
            
            if(Oxygen<=0 && Oxygen>=100)
            {
                return false;
            }

            if (Fertilizer <= 0 && Fertilizer >= 100)
            {
                return false;
            }

            if (Water <= 0 && Water >= 100)
            {
                return false;
            }

            return true;
        }

        public void InitTime()
        {
            currTime = 60f;
        }

        public int Oxygen;
        public int Fertilizer;
        public int Water;
        public int Diamonds;
        public int Bird;
        public int DiamondsPig;
        public EFunctionType functionType;
        public UnityEngine.RectTransform Rect;

        public float currTime;
        public int level;
    }
}
