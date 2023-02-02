using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using DataCs;
using MyGameFrameWork;
public class Csv2CsSimple
{
    static string datacsvpath = Data_FilePath.CsvPathWithCs_Path;//csv�ļ������ַ
    static string datapath = Data_FilePath.CsDataSavePath_Path;//Data���뱣���ַ
    /// <summary>
    /// ���������ļ�ת����CS�ļ�
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
    /// ��������data.cs
    /// </summary>
    /// <param name="path">·��</param>
    /// <param name="name">�ļ�����</param>
    /// <returns></returns>
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
