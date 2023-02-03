using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace MyGameFrameWork
{
    /// <summary>
    /// 场景控制器
    /// </summary>
    public class SceneStateC
    {
        private ISceneState m_State;
        Dictionary<string, System.Object> control_data = new Dictionary<string, System.Object>();
        Dictionary<string, ISceneState> control_state = new Dictionary<string, ISceneState>();
        public SceneStateC() { }

        /// <summary>
        /// 切换状态机
        /// </summary>
        /// <param name="state"></param>
        /// <param name="LoadSceneName"></param>
        /// <param name="obj"></param>
        public void SetState(string state_name, System.Object obj = null)
        {
            if (m_State != null)
            {
                m_State.StateEnd();
            }
            if (control_state.ContainsKey(state_name) || control_state[state_name] != null)
            {
                m_State = control_state[state_name];
                m_State.StateBegin(obj);
            }
            else
            {
                Debug.LogError("null");
            }
            //LoadScene(LoadSceneName);
        }

        private void LoadScene(string loadSceneName)
        {
            if (loadSceneName == null || loadSceneName.Length == 0)
            {
                return;
            }
            SceneManager.LoadScene(loadSceneName);
        }

        public void Update()
        {
            if (m_State != null)
                m_State.StateUpdate();
        }

        /// <summary>
        /// 可以存入全局数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        public void SetData(string str, System.Object obj)
        {
            Debug.Log(str);
            if (control_data.ContainsKey(str))
            {
                control_data[str] = obj;
            }
            else {
                control_data.Add(str, obj);
            }
        }

        /// <summary>
        /// 取出全局数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public System.Object GetData(string str)
        {
            if (!control_data.ContainsKey(str))
                return 0;
            return control_data[str];
        }

        public void AddState(string name, ISceneState sceneState)
        {
            if (sceneState != null)
                control_state.Add(name, sceneState);
        }
    }
}


