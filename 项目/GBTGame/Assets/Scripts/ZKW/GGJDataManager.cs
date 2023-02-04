using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameFrameWork
{
    public enum EFunctionType
    {
        Null,
        Boomer,
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
        }

        public int Oxygen;
        public int Fertilizer;
        public int Water;
        public int Diamonds;
        public int Bird;
        public int DiamondsPig;
        public EFunctionType functionType;
    }
}
