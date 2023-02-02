///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMaskController : MonoBehaviour
{
	private Material material;

	private int alphaCode;

	[SerializeField]
	private float maskDuration;

	public UIMaskController()
	{
		maskDuration = 1f;
	}
	
	private void Start()
	{
		material = GetComponent<RawImage>().material;
		alphaCode = Shader.PropertyToID("_Alpha");
	}

	private float ticks = 1f;
	private int sequence = 1;
	private void Update()
	{
		ticks = Mathf.Clamp(ticks - Time.deltaTime / maskDuration * sequence, 0f, 1.11f);
		material.SetFloat(alphaCode, ticks);
		if (ticks <= 0f && Input.anyKeyDown)
		{
			sequence = -1;
			ticks = 0f;
		}

		if (ticks >= 1.1f)
		{
			
			SceneManager.LoadScene("MainMenu");
		}
	}
}
