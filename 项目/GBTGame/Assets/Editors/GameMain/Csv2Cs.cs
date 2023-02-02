using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;
using System;
using System.Text;
using DataCs;
using MyGameFrameWork;
#if UNITY_EDITOR
public class Csv2Cs : EditorWindow
{
    static Csv2Cs myWindow;

    static string csvpath = "";

    static string cspath = "";


    [MenuItem("Tool/Data/CSV2CS")]

    static void Main()
    {
        csvpath = Data_FilePath.CsvPathWithCs_Path;
        cspath = Data_FilePath.CsDataSavePath_Path;

        myWindow = (Csv2Cs)EditorWindow.GetWindow(typeof(Csv2Cs), false, "CsvToCs", true);//创建窗口
        myWindow.position = new Rect(0, 0, 200, 0);
        myWindow.Show();//展示
    }

    void OnEnable()
    {

    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("请输入存放csv路径");
        csvpath = EditorGUILayout.TextField(csvpath);
        EditorGUILayout.EndHorizontal(); 

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("请输入存放cs路径");
        cspath = EditorGUILayout.TextField(cspath);
        EditorGUILayout.EndHorizontal();
        
        
        if (GUILayout.Button("生成数据类"))
        {
            if (csvpath.Contains("Assets") && cspath.Contains("Assets"))
            {
                CreateFile(csvpath, cspath);
            }
        }
    }

    static void CreateFile(string datacsvpath,string datapath)
    {
        if (Directory.Exists(datacsvpath)&& Directory.Exists(datapath))//如果存在CSV的文件夹
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
            Debug.LogError("不存在指定的文件夹，需要手动创建！");
        }
    }

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