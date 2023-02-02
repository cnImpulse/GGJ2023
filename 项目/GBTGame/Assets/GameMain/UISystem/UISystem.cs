using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class UISystem : MonoBehaviour
    {
        public GameObject[] Roots;//下标越大层级越大

        private void Awake()
        {
            instance = this;
        }

        private static UISystem instance;
        public static UISystem Instance
        {
            get { return instance; }
        }

        public bool OpenUIForm(string UIFormName, System.Object obj = null)
        {
            int id = Data_UIFormID.Dic[UIFormName].ID;
            string path = Data_UIFormID.Dic[UIFormName].path;
            if (ObjectPoolSystem.Instance.TestUIFormPool(id))
            {
                UIForm temp = ObjectPoolSystem.Instance.GetUIFormFormPool(id);
                if (temp != null)
                {
                    temp.OnOpen(obj);
                    return true;
                }
            }
            else
            {
                if (Data_UIFormID.Dic[UIFormName].root <= Roots.Length && Data_UIFormID.Dic[UIFormName].root > 0)
                {
                    GameObject temp = GameObject.Instantiate((GameObject)Resources.Load(path));

                    temp.transform.SetParent(Roots[Data_UIFormID.Dic[UIFormName].root - 1].transform, false);
                    temp.GetComponent<UIForm>().OnOpen(obj);
                    return true;
                }
                Debug.LogError("层级参数有误！");
                return false;
            }
            return false;
        }

        public void CloseUIForm(string UIFormName, UIForm obj)
        {
            int id = Data_UIFormID.Dic[UIFormName].ID;
            obj.OnClose();
            ObjectPoolSystem.Instance.ReBackUIFormPool(id, obj);
        }

        public UIItem OpenUIItem(string UIItemName, UIForm Parent, System.Object obj = null)
        {
            int id = Data_UIItemID.Dic[UIItemName].ID;
            string path = Data_UIItemID.Dic[UIItemName].path;
            if (ObjectPoolSystem.Instance.TestUIItemPool(id))
            {
                UIItem temp = ObjectPoolSystem.Instance.GetUIItemFormPool(id);
                if (temp != null)
                {
                    temp.OnOpen(obj);
                    return temp;
                }
            }
            else
            {
                GameObject temp = GameObject.Instantiate((GameObject)Resources.Load(path));
                temp.GetComponent<UIItem>().OnOpen(obj);
                temp.GetComponent<UIItem>().SetParent(Parent);
                return temp.GetComponent<UIItem>();
            }
            return null;
        }

        public void CloseUIItem(string UIItemName, UIItem obj)
        {
            int id = Data_UIItemID.Dic[UIItemName].ID;
            obj.OnClose();
            ObjectPoolSystem.Instance.ReBackUIItemPool(id, obj);
        }
    }
}


