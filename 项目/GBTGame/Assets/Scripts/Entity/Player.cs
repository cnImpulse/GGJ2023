using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;
using System;

namespace MyGameFrameWork
{
    public class Player : MonoBehaviour
    {
        public Player Other;
        public GameObject m_hook;
        public RectTransform m_rect_qianzi, m_rect_arrow;
        public KeyCode KeyCode = KeyCode.S;
        public KeyCode SkillCode = KeyCode.W;

        public float AngleOffset = 0;
        public float HandleAngleArea = 180;
        public float HandleMoveSpeed = 100;
        public float HookMoveSpeed = 100;
        public float HookReturnSpeed = 100;
        public float CurRealAngle => m_CurAngle + AngleOffset;
        public bool Stop = false;
        public float StopTime = 0;

        private float m_CurAngle = 0;
        private bool m_IsRight = true;
        private bool m_IsHandleMoving = false;
        private bool m_IsHookReturn = false;

        private GameObject m_CurTool = default;

        // Start is called before the first frame update
        void Start()
        {

        }

        private float m_CountDown = 0;
        private int m_AddSpped = 0;

        // Update is called once per frame
        void Update()
        {
            m_CountDown -= Time.deltaTime;
            StopTime -= Time.deltaTime;
            if (m_CountDown < 0)
            {
                m_CountDown = 0;
                m_AddSpped = 0;
            }

            if (StopTime < 0)
            {
                StopTime = 0;
                Stop = false;
            }

            m_rect_qianzi.gameObject.SetActive(m_IsHandleMoving);
            m_rect_arrow.gameObject.SetActive(!m_IsHandleMoving);
            if (m_IsHandleMoving)
            {
                if ((Input.GetKeyDown(KeyCode) && !Stop) || !Camera.main.pixelRect.Contains(m_hook.transform.position)) 
                {
                    m_IsHookReturn = true;
                }

                m_rect_qianzi.localEulerAngles = new Vector3(0, 0, CurRealAngle);
                var length = m_rect_qianzi.rect.height;
                if (m_IsHookReturn)
                {
                    length -= Time.deltaTime * (HookReturnSpeed + m_AddSpped);
                }
                else
                {
                    length += Time.deltaTime * (HookMoveSpeed + m_AddSpped);
                }

                if (length < 0)
                {
                    length = 0;
                    m_IsHandleMoving = false;

                    if (m_CurTool != null)
                    {
                        EventManagerSystem.Instance.Invoke2(Data_EventName.DestoryTool_str, new DestoryToolEventArgs(m_CurTool));
                    }

                    m_CurTool = null;
                }

                m_rect_qianzi.sizeDelta = new Vector2(m_rect_qianzi.rect.width, length);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode) && !Stop)
                {
                    m_IsHandleMoving = true;
                    m_IsHookReturn = false;
                }

                UpdateHandleAngle();
            }

            if (Input.GetKeyDown(SkillCode) && !Stop)
            {
                if (GGJDataManager.Instance.functionType == EFunctionType.Boomer)
                {
                    if (m_CurTool)
                    {
                        Destroy(m_CurTool);
                    }

                    m_CurTool = null;
                }
                else if (GGJDataManager.Instance.functionType == EFunctionType.AddSpeed)
                {
                    m_CountDown = 5;
                    m_AddSpped = 100;
                }
                else if (GGJDataManager.Instance.functionType == EFunctionType.Stop)
                {
                    Other.StopTime = 5;
                    Other.Stop = true;
                }

                GGJDataManager.Instance.functionType = EFunctionType.Null;
            }
        }

        private void UpdateHandleAngle()
        {
            if (m_IsRight)
            {
                m_CurAngle += HandleMoveSpeed * Time.deltaTime;
            }
            else
            {
                m_CurAngle -= HandleMoveSpeed * Time.deltaTime;
            }

            if (m_CurAngle > HandleAngleArea)
            {
                m_IsRight = false;
            }
            else if (m_CurAngle < 0)
            {
                m_IsRight = true;
            }

            m_CurAngle = Mathf.Clamp(m_CurAngle, 0, HandleAngleArea);
            m_rect_arrow.localEulerAngles = new Vector3(0, 0, CurRealAngle);
        }

        public void OnHookTool(GameObject go)
        {
            if (m_CurTool == null)
            {
                EventManagerSystem.Instance.Invoke2(Data_EventName.CrashTool_str, new CrashToolEventArgs(go));
                m_CurTool = go;
                go.transform.SetParent(m_hook.transform);

                m_IsHookReturn = true;
            }
        }
    }

}