///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用方法：将此组件的enabled调为true即可
/// </summary>
public class ShakenCamera : MonoBehaviour
{
	[SerializeField, DisplayName("震动等级")]
	private float shakeLevel;// 震动幅度
	[SerializeField, DisplayName("震动时间")]
	private float setShakeTime;	// 震动时间
	[SerializeField, DisplayName("震动FPS")]
	private float shakeFps;	// 震动的FPS
 
	private bool isshakeCamera = false;// 震动标志
	private float fps;
	private float shakeTime = 0.0f;
	private float frameTime = 0.0f;
	private float shakeDelta = 0.005f;
	private Camera selfCamera;

	public ShakenCamera()
	{
		shakeLevel = 3f;
		setShakeTime = 0.5f;
		shakeFps = 60f;
	}
 
	void OnEnable()
	{
		isshakeCamera = true;
		selfCamera = gameObject.GetComponent<Camera>();
		shakeTime = setShakeTime;
		fps = shakeFps;
		frameTime = 0.03f;
		shakeDelta = 0.005f;
	}
 
	void OnDisable()
	{
		selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
		isshakeCamera = false;
	}
		
	// Update is called once per frame
	void Update()
	{
		if (isshakeCamera)
		{
			if (shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0)
				{
					enabled = false;
				}
				else
				{
					frameTime += Time.deltaTime;
 
					if (frameTime > 1.0 / fps)
					{
						frameTime = 0;
						selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * UnityEngine.Random.value), shakeDelta * (-1.0f + shakeLevel * UnityEngine.Random.value), 1.0f, 1.0f);
					}
				}
			}
		}
	}
}
