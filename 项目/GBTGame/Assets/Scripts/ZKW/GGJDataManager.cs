using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameFrameWork
{
    public class GGJDataManager
    {
        private GGJDataManager() { }
        //单例模式
        private static GGJDataManager instance = new GGJDataManager();
        public static GGJDataManager Instance
        {
            get { return instance; }
        }

        void Init()
        {
            Oxygen = 0;
            Fertilizer = 0;
            Water = 0;
            Diamonds = 0;
            Bird = 0;
            DiamondsPig = 0;
        }

        public int Oxygen;
        public int Fertilizer;
        public int Water;
        public int Diamonds;
        public int Bird;
        public int DiamondsPig;
    }
}
