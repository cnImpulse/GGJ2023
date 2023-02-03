using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 19:39:36
public partial class HandleForm : UIForm
{
	public float AngleOffset = 0;
	public float HandleAngleArea = 180;
	public float HandleMoveSpeed = 100;
	public float CurRealAngle => m_CurAngle + AngleOffset;

	private float m_CurAngle = 0;
	private bool m_IsRight = true;
	private bool m_IsHandleMoving = false;

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
	}

    public override void Update()
    {
        base.Update();

		if (m_IsHandleMoving)
        {

        }
        else
        {
			if (Input.GetKeyDown(KeyCode.S))
			{
				m_IsHandleMoving = true;
			}
			else
			{
				UpdateHandleAngle();
			}
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

    public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		
	}

	private void ReleaseEvent()
	{

	}
}

