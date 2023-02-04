using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public partial class GameMain : MonoBehaviour
    {
        /*public GameObject Enity1;
        public GameObject Player;

        public GameObject Spawn1;
        public GameObject Spawn2;
        public GameObject Spawn3;
        public GameObject Spawn4;
        public GameObject Spawn5;
        public GameObject Spawn6;

        public GameObject Tower1;
        public GameObject Tower2;
        public GameObject Tower3;
        public GameObject Tower4;
        public GameObject Tower5;

        public GameObject HPBarCanvas;*/
        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            Screen.SetResolution(1920, 1080, false);
        }
        void Start()
        {
            JsonSystem.Instance.ReadAllJsonToAttr();
            //Attr4<string, string, string, string> temp =  AttrSystem.Instance.GetData("JsonExample","0") as Attr4<string, string, string, string>;
            //Attr4<string, string, string, string> temp2 = AttrSystem.Instance.GetData("JsonExample", "1") as Attr4<string, string, string, string>;

            AttrList temp = AttrSystem.Instance.GetData("ToolTable", "3002") as AttrList;
            Debug.Log(temp);

            AttrList temp2 = AttrSystem.Instance.GetData("ToolTable", "1") as AttrList;
            Debug.Log(temp2);

            AttrList temp3 = AttrSystem.Instance.GetData("ToolTable", "3005") as AttrList;
            Debug.Log(temp3);
            //Debug.Log(temp2);


            Debug.Log("GameMainStart");

            GGJDataManager.Instance.Init();

            StateInit();//状态初始化
            /*sceneStateC.SetData("Enity1", Enity1);
            sceneStateC.SetData("Player", Player);
            sceneStateC.SetData("Spawn1", Spawn1);
            sceneStateC.SetData("Spawn2", Spawn2);
            sceneStateC.SetData("Spawn3", Spawn3);
            sceneStateC.SetData("Spawn4", Spawn4);
            sceneStateC.SetData("Spawn5", Spawn5);
            sceneStateC.SetData("Spawn6", Spawn6);
            sceneStateC.SetData("HPBarCanvas", HPBarCanvas);

            sceneStateC.SetData("Tower1", Tower1);
            sceneStateC.SetData("Tower2", Tower2);
            sceneStateC.SetData("Tower3", Tower3);
            sceneStateC.SetData("Tower4", Tower4);
            sceneStateC.SetData("Tower5", Tower5);*/
        }

        // Update is called once per frame
        void Update()
        {
            sceneStateC.Update();
        }
    }
}
