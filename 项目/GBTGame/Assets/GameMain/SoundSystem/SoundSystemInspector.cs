using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace MyGameFrameWork
{
#if UNITY_EDITOR
    [CustomEditor(typeof(SoundSystem))]

    public class SoundSystemInspector : Editor
    {
        SoundSystem soundSystem;
        GameObject Root;

        string music_num;
        string effect_num;

        SerializedProperty music_managers;
        SerializedProperty effect_managers;


        private void OnEnable()
        {
            soundSystem = (SoundSystem)target;
            Root = soundSystem.gameObject;

            music_managers = serializedObject.FindProperty("MusicManagers");
            effect_managers = serializedObject.FindProperty("EffectManagers");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            GUILayout.TextArea("MusicManager Num:");
            music_num = GUILayout.TextArea(music_num);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.TextArea("EffectManager Num:");
            effect_num = GUILayout.TextArea(effect_num);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("自动绑定"))
            {
                music_managers.ClearArray();
                effect_managers.ClearArray();
                CreateManager(music_num, effect_num);
            }
            if (GUILayout.Button("清除所有子物体"))
            {
                DeleteManger();
            }
            EditorGUILayout.EndVertical();
        }

        private void CreateManager(string music_num, string effect_num)
        {
            if (music_num == null || effect_num == null)
            {
                Debug.LogError("请输入正确的管理器数字");
                return;
            }
            int _music_num = 1, _effect_num = 1;
            if (!int.TryParse(music_num, out _music_num) || !int.TryParse(effect_num, out _effect_num))
            {
                Debug.LogError("请输入正确的管理器数字");
                return;
            }
            if (_music_num < 1 && _effect_num < 1)
            {
                Debug.LogError("管理器数字必须大于1");
                return;
            }
            CreateManager(_music_num, _effect_num);
        }

        private void CreateManager(int music_num, int effect_num)
        {
            while (Root.transform.childCount != 0)
            {
                DestroyImmediate(Root.transform.GetChild(0).gameObject);
            }

            GameObject music_num_managers = new GameObject("MusicManagers");
            music_num_managers.transform.SetParent(Root.transform);

            AudioSource temp;

            for (int i = 0; i < music_num; i++)
            {
                GameObject music_manager = new GameObject("MusicManager" + (i + 1).ToString());
                temp = music_manager.AddComponent<AudioSource>();
                temp.playOnAwake = false;
                music_manager.transform.SetParent(music_num_managers.transform);

                music_managers.arraySize += 1;
                music_managers.GetArrayElementAtIndex(music_managers.arraySize - 1).objectReferenceValue = music_manager;
            }

            GameObject effect_num_managers = new GameObject("EffectManagers");
            effect_num_managers.transform.SetParent(Root.transform);

            for (int i = 0; i < effect_num; i++)
            {
                GameObject effect_manager = new GameObject("EffectManager" + (i + 1).ToString());
                temp = effect_manager.AddComponent<AudioSource>();
                temp.playOnAwake = false;
                effect_manager.transform.SetParent(effect_num_managers.transform);

                effect_managers.arraySize += 1;
                effect_managers.GetArrayElementAtIndex(effect_managers.arraySize - 1).objectReferenceValue = effect_manager;
            }
            Debug.LogError(music_managers.arraySize);
            Debug.LogError(effect_managers.arraySize);
            serializedObject.ApplyModifiedProperties();
        }

        private void DeleteManger()
        {
            while (Root.transform.childCount != 0)
            {
                DestroyImmediate(Root.transform.GetChild(0).gameObject);
            }
            music_managers.ClearArray();
            effect_managers.ClearArray();
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}


