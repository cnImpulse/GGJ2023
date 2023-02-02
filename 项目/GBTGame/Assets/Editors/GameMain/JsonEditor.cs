using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;
using DataCs;
using MyGameFrameWork;

public class JsonEditor 
{
    static string path = Data_FilePath.JsonSavePath_Path;
    static string csvpath = Data_FilePath.CsvPathWithJson_Path;



#if UNITY_EDITOR
    [MenuItem("Tool/Json/CSVTOJson")]
#endif
    static void CSVTOJson()
    {
        if (Directory.Exists(csvpath))
        {
            DirectoryInfo direction = new DirectoryInfo(csvpath);
            FileInfo[] files = direction.GetFiles("*.csv");
            
            
            for(int i=0;i<files.Length;i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                string name = files[i].Name.Split('.')[0];
                CodeCreate.CreateORwriteConfigFile(path, name + ".json", ReadCSVToJsonData(csvpath, name).ToJson());
                Debug.Log(name + "  OK!");
            }
        }
    }

    /// <summary>
    /// 用于保存文件至指定路径
    /// </summary>
    /// <param name="path">保存路径</param>
    /// <param name="name">文件名称</param>
    /// <param name="info"></param>
    
    static void JsonDataAddArr(JsonData data, string arr_name, string[] arr)
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
    static void JsonDataAddArr(JsonData data, string arr_name, List<string> arr)
    {
        data[arr_name] = new JsonData();
        for (int i = 0; i <= arr.Count; i++)
        {
            data[arr_name].Add(i);
        }
        data[arr_name][0] = arr.Count.ToString();
        for (int i = 1; i <= arr.Count; i++)
        {
            data[arr_name][i] = arr[i - 1];
        }
    }
    static JsonData ReadCSVToJsonData(string path,string name)
    {
        string[] true_txt = System.IO.File.ReadAllLines(path+"\\"+name+".csv");//包含注释的所有文本项
        List<string> txt = new List<string>();//不包含注释的所有文本行
        for (int i=0;i< true_txt.Length;i++)
        {
            if(true_txt[i].Length==0|| true_txt[i][0]=='#')
            {
                continue;
            }
            txt.Add(true_txt[i]);
        }
        //创建JsonData对象
        JsonData data = new JsonData();
        //设置表名称
        data["filename"] = name;
        //获取CSV文件的头部信息
        string[] head = txt[0].Split(',');
        JsonDataAddArr(data, "default", head);
        //填充信息
        List<List<string>> list_str = new List<List<string>>(head.Length);
        for(int i=0;i< head.Length; i++)
        {
            List<string> temp = new List<string>(txt.Count - 1);
            for(int j=0;j< txt.Count - 1;j++)
            {
                temp.Add("");
            }
            list_str.Add(temp);
        }
        for (int i=1;i<txt.Count; i++)
        {
            string[] temp = txt[i].Split(',');
            for (int j = 0; j < temp.Length; j++)
            {
                list_str[j][i-1] = temp[j];
            }
        }
        //添加到jsondata对象
        for (int i=0;i< head.Length;i++)
        {
            JsonDataAddArr(data, head[i], list_str[i]);
        }
        return data;
    }


    

}
