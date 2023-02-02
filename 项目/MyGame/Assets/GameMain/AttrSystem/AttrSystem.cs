using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class AttrSystem
    {
        private AttrSystem()
        {
            list2 = new List<AttrModel2<string, string>>(AttrSystemModel.table_init_length);
            list3 = new List<AttrModel3<string, string, string>>(AttrSystemModel.table_init_length);
            list4 = new List<AttrModel4<string, string, string, string>>(AttrSystemModel.table_init_length);
            list5 = new List<AttrModel5<string, string, string, string, string>>(AttrSystemModel.table_init_length);
            list6 = new List<AttrModel6<string, string, string, string, string, string>>(AttrSystemModel.table_init_length);
            table_attr_num = new Dictionary<string, int>(AttrSystemModel.table_init_length);
            table_attr_index = new Dictionary<string, int>(AttrSystemModel.table_init_length);
        }
        //单例模式
        private static AttrSystem instance = new AttrSystem();
        public static AttrSystem Instance
        {
            get { return instance; }
        }

        Dictionary<string, int> table_attr_num;//表有几个属性
        Dictionary<string, int> table_attr_index;//表所在的下标

        List<AttrModel2<string, string>> list2;
        List<AttrModel3<string, string, string>> list3;
        List<AttrModel4<string, string, string, string>> list4;
        List<AttrModel5<string, string, string, string, string>> list5;
        List<AttrModel6<string, string, string, string, string, string>> list6;

        /// <summary>
        /// 加载Json文件
        /// </summary>
        public void LoadJson()
        {
            EventManagerSystem.Instance.Invoke<int>("设置加载任务", JsonSystem.Instance.GetJsonFileNum());
            JsonSystem.Instance.ReadAllJsonToAttr();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public IAttr GetData(string table_name, string main_id)
        {
            if (table_attr_num.ContainsKey(table_name) && table_attr_index.ContainsKey(table_name))
            {
                switch (table_attr_num[table_name])
                {
                    case 2:
                        {
                            return list2[table_attr_index[table_name]].FindMain(main_id);
                        }
                    case 3:
                        {
                            return list3[table_attr_index[table_name]].FindMain(main_id);
                        }
                    case 4:
                        {
                            return list4[table_attr_index[table_name]].FindMain(main_id);
                        }
                    case 5:
                        {
                            return list5[table_attr_index[table_name]].FindMain(main_id);
                        }
                    case 6:
                        {
                            return list6[table_attr_index[table_name]].FindMain(main_id);
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
            else
            {
                Debug.Log("没有该数据表");
                return null;
            }
        }
        /// <summary>
        /// 获取表的行数
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public int GetTableColNum(string table_name)
        {
            if (table_attr_num.ContainsKey(table_name) && table_attr_index.ContainsKey(table_name))
            {
                switch (table_attr_num[table_name])
                {
                    case 2:
                        {
                            return list2[table_attr_index[table_name]].GetColNum();
                        }
                    case 3:
                        {
                            return list3[table_attr_index[table_name]].GetColNum();
                        }
                    case 4:
                        {
                            return list4[table_attr_index[table_name]].GetColNum();
                        }
                    case 5:
                        {
                            return list5[table_attr_index[table_name]].GetColNum();
                        }
                    case 6:
                        {
                            return list6[table_attr_index[table_name]].GetColNum();
                        }
                    default:
                        {
                            return 0;
                        }
                }
            }
            else
            {
                Debug.Log("没有该数据表");
                return 0;
            }
        }

        /// <summary>
        /// 添加属性表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr2"></param>
        public void SetData(string name, AttrModel2<string, string> attr2)
        {
            table_attr_num.Add(name, 2);
            table_attr_index.Add(name, list2.Count);
            list2.Add(attr2);
        }
        public void SetData(string name, AttrModel3<string, string, string> attr3)
        {
            table_attr_num.Add(name, 3);
            table_attr_index.Add(name, list3.Count);
            list3.Add(attr3);
        }
        public void SetData(string name, AttrModel4<string, string, string, string> attr4)
        {
            table_attr_num.Add(name, 4);
            table_attr_index.Add(name, list4.Count);
            list4.Add(attr4);
        }
        public void SetData(string name, AttrModel5<string, string, string, string, string> attr5)
        {
            //Debug.Log(name);
            table_attr_num.Add(name, 5);
            table_attr_index.Add(name, list5.Count);
            list5.Add(attr5);
            //Debug.Log(attr5);
        }
        public void SetData(string name, AttrModel6<string, string, string, string, string, string> attr6)
        {
            //Debug.Log(name);
            table_attr_num.Add(name, 6);
            table_attr_index.Add(name, list6.Count);
            list6.Add(attr6);
            //Debug.Log(attr6);
        }
    }
}

