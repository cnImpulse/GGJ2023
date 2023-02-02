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

        myWindow = (Csv2Cs)EditorWindow.GetWindow(typeof(Csv2Cs), false, "CsvToCs", true);//��������
        myWindow.position = new Rect(0, 0, 200, 0);
        myWindow.Show();//չʾ
    }

    void OnEnable()
    {

    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("��������csv·��");
        csvpath = EditorGUILayout.TextField(csvpath);
        EditorGUILayout.EndHorizontal(); 

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("��������cs·��");
        cspath = EditorGUILayout.TextField(cspath);
        EditorGUILayout.EndHorizontal();
        
        
        if (GUILayout.Button("����������"))
        {
            if (csvpath.Contains("Assets") && cspath.Contains("Assets"))
            {
                CreateFile(csvpath, cspath);
            }
        }
    }

    static void CreateFile(string datacsvpath,string datapath)
    {
        if (Directory.Exists(datacsvpath)&& Directory.Exists(datapath))//�������CSV���ļ���
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
            Debug.LogError("������ָ�����ļ��У���Ҫ�ֶ�������");
        }
    }

    static string GenerationToCSData(string path, string name)
    {
        string[] true_txt = null;
        try
        {
            true_txt = System.IO.File.ReadAllLines(path + "\\" + name + ".csv");//����ע�͵������ı���
        }
        catch
        {
            Debug.LogError("��ȷ���ļ��ѱ�������ѹر�");
        }

        if (true_txt == null)
        {
            return "!��ȷ���ļ��ѱ�������ѹر�";
        }

        string[] arr_type_list = null;//�����б�
        string[] arr_name_list = null;//��������
        string[] temp_list;//��ʱ�б�
        List<string[]> temp_lists = new List<string[]>();//��ʱ�б��飻

        int num = 0;//0��ʾ�����б�1��ʾ��������
        int model = 0;//0��ʾ�޹������ɣ�1��ʾ��������

        for (int i = 0; i < true_txt.Length; i++)
        {
            if (true_txt[i].Length == 0 || true_txt[i][0] == '#')//����ע�ͺͿ���
            {
                continue;
            }
            if ((true_txt[i][0] == '@' || true_txt[i][0] == '!') && num < 2)//������
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
