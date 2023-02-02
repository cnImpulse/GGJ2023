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
        myWindow = (EventCreate)EditorWindow.GetWindow(typeof(EventCreate), false, "EventCreate", true);//创建窗口
        myWindow.position = new Rect(0, 0, 200, height);
        myWindow.Show();//展示
    }

    void OnEnable()
    {

    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        //EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("填写事件类名：");
        //EditorGUILayout.EndHorizontal();
        classname = EditorGUILayout.TextField(classname);//单行
        if(GUILayout.Button("添加参数"))
        {
            argsnum++;
            arg_names.Add("");
            type_names.Add("");
            height += 20;
            myWindow.position = new Rect(myWindow.position.x, myWindow.position.y, 200, height);
        }
        if(GUILayout.Button("减少参数"))
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
        GUILayout.Label("类型");
        GUILayout.Label("名称");
        EditorGUILayout.EndHorizontal();
        for (int i=0;i<argsnum;i++)
        {
            EditorGUILayout.BeginHorizontal();
            type_names[i] = EditorGUILayout.TextField(type_names[i]);
            arg_names[i] = EditorGUILayout.TextField(arg_names[i]);
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("生成代码"))
        {
            CodeCreate.CreateORwriteConfigFile(Data_FilePath.Event_Path,classname+"EventArgs.cs", CodeCreate.EventArgsGenertion(arg_names, type_names, classname));
            Debug.Log("代码生成 OK!");
        }
        EditorGUILayout.EndVertical();
    }

}
