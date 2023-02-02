using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoundImage))]
public class RoundImageInspector : Editor
{
    RoundImage roundImage;
    GameObject Root;

    SerializedProperty Radius;

    SerializedProperty TriangleNum;

    string _Radius;
    string _TriangleNum;

    private void OnEnable()
    {
        roundImage = (RoundImage)target;
        Root = roundImage.gameObject;

        Radius = serializedObject.FindProperty("Radius");
        TriangleNum = serializedObject.FindProperty("TriangleNum");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.TextArea("_Radius:");
        _Radius = GUILayout.TextArea(_Radius);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.TextArea("_TriangleNum:");
        _TriangleNum = GUILayout.TextArea(_TriangleNum);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("����"))
        {
            float a;
            int b;
            if(float.TryParse(_Radius, out a))
            {
                Radius.floatValue = a;
            }
            else
            {
                Debug.LogError("�뾶�������");
            }
            if(int.TryParse(_TriangleNum,out b))
            {
                if(b>0)
                    TriangleNum.intValue = b;
                else
                    Debug.LogError("�����θ�������");
            }
            else
            {
                Debug.LogError("�����θ�������");
            }
            serializedObject.ApplyModifiedProperties();
        }

        EditorGUILayout.EndVertical();
    }
}
