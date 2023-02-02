using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

namespace MyGameFrameWork
{
    public class JsonSystem
    {
        string path = "Assets/File";
        private JsonSystem() { }
        //单例模式
        private static JsonSystem instance = new JsonSystem();
        public static JsonSystem Instance
        {
            get { return instance; }
        }
        public void Test()
        {
            ReadAllJsonToAttr();
        }
        /// <summary>
        /// 获取指定文件夹下的json数量
        /// </summary>
        /// <returns></returns>
        public int GetJsonFileNum()
        {
            Debug.Log("设置加载任务");
            if (Directory.Exists(path))
            {
                DirectoryInfo direction = new DirectoryInfo(path);
                FileInfo[] files = direction.GetFiles("*.json");
                Debug.Log("任务数量：" + files.Length);
                return files.Length;
            }
            return 0;
        }
        /// <summary>
        /// 获取指定路径下的所有json文件并加载到AttrSystem中
        /// </summary>
        public void ReadAllJsonToAttr()
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo direction = new DirectoryInfo(path);
                FileInfo[] files = direction.GetFiles("*.json");
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".meta"))
                    {
                        continue;
                    }
                    JsonData data = JsonMapper.ToObject(ReadFile(files[i].FullName));
                    if (data == null)
                    {
                        Debug.Log("无法获取json");
                        //EventManagerSystem.Instance.Invoke("加载失败")
                    }
                    else
                    {
                        Debug.Log(data["filename"]);
                        string file_name = data["filename"].ToString();
                        string default_table = data["default"].ToString();
                        int attr_num = int.Parse(data["default"][0].ToString());//属性个数,行数
                        int row_num = int.Parse(data[data["default"][1].ToString()][0].ToString());//第一个属性的行数
                        switch (attr_num)
                        {
                            case 2:
                                {
                                    AttrModel2<string, string> a2 = new AttrModel2<string, string>(file_name);
                                    for (int k = 1; k <= row_num; k++)//列数
                                    {
                                        a2.Add(data[data["default"][1].ToString()][k].ToString(),
                                                data[data["default"][2].ToString()][k].ToString());
                                    }
                                    AttrSystem.Instance.SetData(file_name, a2);
                                    break;
                                }
                            case 3:
                                {
                                    AttrModel3<string, string, string> a3 = new AttrModel3<string, string, string>(file_name);
                                    for (int k = 1; k <= row_num; k++)//列数
                                    {
                                        a3.Add(data[data["default"][1].ToString()][k].ToString(),
                                                data[data["default"][2].ToString()][k].ToString(),
                                                data[data["default"][3].ToString()][k].ToString());
                                    }
                                    AttrSystem.Instance.SetData(file_name, a3);
                                    break;
                                }
                            case 4:
                                {
                                    AttrModel4<string, string, string, string> a4 = new AttrModel4<string, string, string, string>(file_name);
                                    for (int k = 1; k <= row_num; k++)//列数
                                    {
                                        a4.Add(data[data["default"][1].ToString()][k].ToString(),
                                                data[data["default"][2].ToString()][k].ToString(),
                                                data[data["default"][3].ToString()][k].ToString(),
                                                data[data["default"][4].ToString()][k].ToString());
                                    }
                                    AttrSystem.Instance.SetData(file_name, a4);
                                    break;
                                }
                            case 5:
                                {
                                    AttrModel5<string, string, string, string, string> a5 = new AttrModel5<string, string, string, string, string>(file_name);
                                    for (int k = 1; k <= row_num; k++)//列数
                                    {
                                        a5.Add(data[data["default"][1].ToString()][k].ToString(),
                                                data[data["default"][2].ToString()][k].ToString(),
                                                data[data["default"][3].ToString()][k].ToString(),
                                                data[data["default"][4].ToString()][k].ToString(),
                                                data[data["default"][5].ToString()][k].ToString());
                                    }
                                    AttrSystem.Instance.SetData(file_name, a5);
                                    break;
                                }
                            case 6:
                                {
                                    AttrModel6<string, string, string, string, string, string> a6 = new AttrModel6<string, string, string, string, string, string>(file_name);
                                    for (int k = 1; k <= row_num; k++)//列数
                                    {
                                        a6.Add(data[data["default"][1].ToString()][k].ToString(),
                                                data[data["default"][2].ToString()][k].ToString(),
                                                data[data["default"][3].ToString()][k].ToString(),
                                                data[data["default"][4].ToString()][k].ToString(),
                                                data[data["default"][5].ToString()][k].ToString(),
                                                data[data["default"][6].ToString()][k].ToString());
                                    }
                                    AttrSystem.Instance.SetData(file_name, a6);
                                    break;
                                }
                        }
                    }
                    Debug.Log("完成一个加载任务");
                    EventManagerSystem.Instance.Invoke("完成一个加载任务");
                }
            }
        }


        void JsonDataAddArr(JsonData data, string arr_name, string[] arr)
        {
            data[arr_name] = new JsonData();
            for (int i = 0; i <= arr.Length; i++)
            {
                data[arr_name].Add(i);
            }
            data[arr_name][0] = arr.Length.ToString();
            for (int i = 1; i <= arr.Length; i++)
            {
                data[arr_name][i] = arr[i - 1];
            }
        }

        /// <summary>
        /// 获取文件夹下的所有json文件
        /// </summary>
        void GetFiles()
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo direction = new DirectoryInfo(path);
                FileInfo[] files = direction.GetFiles("*");
                for (int i = 0; i < files.Length; i++)
                {
                    //忽略关联文件
                    if (files[i].Name.EndsWith(".meta"))
                    {
                        continue;
                    }
                    Debug.Log("文件名:" + files[i].Name);
                    Debug.Log("文件绝对路径:" + files[i].FullName);
                    Debug.Log("文件所在目录:" + files[i].DirectoryName);
                }
            }
        }

        //读取文件
        string ReadFile()
        {
            StreamReader sr = new StreamReader(path + "//" + "BaseBuliding.json");
            StringBuilder sb = new StringBuilder(20);
            while (!sr.EndOfStream)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();
            Debug.Log(sb.ToString());
            return sb.ToString();
        }

        //读取文件
        string ReadFile(string all_path)
        {
            StreamReader sr = new StreamReader(all_path);
            StringBuilder sb = new StringBuilder(20);
            while (!sr.EndOfStream)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();
            return sb.ToString();
        }
    }
}
