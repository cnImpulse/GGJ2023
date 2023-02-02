using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DataCs;
using MyGameFrameWork;

public class EventCreate: EditorWindow
{
    static EventCreate myWindow; 
    static string classname = "";
    static int argsnum = 0;
    static List<string> arg_names = new List<string>();
    static List<string> type_names = new List<string>();

    static float height = 150;

    [MenuItem("Tool/EventCreate")]
    static void Main()
    {
        classname = "";
        argsnum = 0;
        arg_names.Clear();
        type_names.Clear();
        myWindow = (EventCreate)EditorWindow.GetWindow(typeof(EventCreate), false, "EventCreate", true);//��������
        myWindow.position = new Rect(0, 0, 200, height);
        myWindow.Show();//չʾ
    }

    void OnEnable()
    {

    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        //EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("��д�¼�������");
        //EditorGUILayout.EndHorizontal();
        classname = EditorGUILayout.TextField(classname);//����
        if(GUILayout.Button("��Ӳ���"))
        {
            argsnum++;
            arg_names.Add("");
            type_names.Add("");
            height += 20;
            myWindow.position = new Rect(myWindow.position.x, myWindow.position.y, 200, height);
        }
        if(GUILayout.Button("���ٲ���"))
        {
            if(argsnum>=1)
            {
                argsnum--;
                arg_names.RemoveAt(argsnum);
                type_names.RemoveAt(argsnum);
                height -= 20;
                myWindow.position = new Rect(myWindow.position.x, myWindow.position.y, 200, height);
            }
        }
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("����");
        GUILayout.Label("����");
        EditorGUILayout.EndHorizontal();
        for (int i=0;i<argsnum;i++)
        {
            EditorGUILayout.BeginHorizontal();
            type_names[i] = EditorGUILayout.TextField(type_names[i]);
            arg_names[i] = EditorGUILayout.TextField(arg_names[i]);
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("���ɴ���"))
        {
            CodeCreate.CreateORwriteConfigFile(Data_FilePath.Event_Path,classname+"EventArgs.cs", CodeCreate.EventArgsGenertion(arg_names, type_names, classname));
            Debug.Log("�������� OK!");
        }
        EditorGUILayout.EndVertical();
    }

}
