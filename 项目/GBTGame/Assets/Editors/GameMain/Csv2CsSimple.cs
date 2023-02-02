using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using DataCs;
using MyGameFrameWork;
#if UNITY_EDITOR
public class Csv2CsSimple
{
    static string datacsvpath = Data_FilePath.CsvPathWithCs_Path;//csv文件储存地址
    static string datapath = Data_FilePath.CsDataSavePath_Path;//Data代码保存地址
    /// <summary>
    /// 用于数据文件转换到CS文件
    /// </summary>
    [MenuItem("Tool/Data/CSV2CSSimple")]
    static void CSVToCS()
    {
        if (Directory.Exists(datacsvpath))
        {
            DirectoryInfo direction = new DirectoryInfo(datacsvpath);
            FileInfo[] files = direction.GetFiles("*.csv");

            for (int i = 0; i < files.Length; i++)
            {

                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }

                string name = files[i].Name.Split('.')[0];
                CodeCreate.CreateORwriteConfigFile(datapath, "Data_" + name + ".cs", GenerationToCSData(datacsvpath, name));
            }
            Debug.Log("Create OK!");
        }
        else
        {
            Debug.LogError("Create Error! No Files!");
        }
    }


    /// <summary>
    /// 生成数据data.cs
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="name">文件名称</param>
    /// <returns></returns>
    static string GenerationToCSData(string path, string name)
    {
        string[] true_txt = null;
        try
        {
            true_txt = System.IO.File.ReadAllLines(path + "\\" + name + ".csv");//包含注释的所有文本项
        }
        catch
        {
            Debug.LogError("请确保文件已保存或者已关闭");
        }

        if (true_txt == null)
        {
            return "!请确保文件已保存或者已关闭";
        }

        string[] arr_type_list = null;//类型列表
        string[] arr_name_list = null;//类型名称
        string[] temp_list;//临时列表
        List<string[]> temp_lists = new List<string[]>();//临时列表组；

        int num = 0;//0表示类型列表，1表示类型名称
        int model = 0;//0表示无关联生成，1表示关联生成

        for (int i = 0; i < true_txt.Length; i++)
        {
            if (true_txt[i].Length == 0 || true_txt[i][0] == '#')//忽略注释和空行
            {
                continue;
            }
            if ((true_txt[i][0] == '@' || true_txt[i][0] == '!') && num < 2)//类型行
            {
                if (num == 0)
                {
                    arr_type_list = true_txt[i].Split(',');
                }
                else
                {
                    arr_name_list = true_txt[i].Split(',');
                }
                if (true_txt[i][0] == '@')
                {
                    model = 0;
                }
                else if (true_txt[i][0] == '!')
                {
                    model = 1;
                }
                num++;
                continue;
            }
            temp_list = true_txt[i].Split(',');
            temp_lists.Add(temp_list);

        }

        switch (model)
        {
            case 0:
                {
                    return CodeCreate.NoLineGenertion(arr_type_list, arr_name_list, temp_lists, name);

                }
            case 1:
                {
                    return CodeCreate.LineGenertion(arr_type_list, arr_name_list, temp_lists, name);
                }
            default:
                {
                    return "";
                }
        }
    }
}
#endif