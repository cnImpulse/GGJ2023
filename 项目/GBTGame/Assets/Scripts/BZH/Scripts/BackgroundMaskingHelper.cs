///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMaskingHelper : MonoBehaviour
{
	[SerializeField, Range(0f, 1f)]
	private float greyScale;

	public BackgroundMaskingHelper()
	{
		greyScale = 0.55f;
	}
	
	private void Awake()
	{
		SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		spriteRenderer.color = new Vector4(greyScale, greyScale, greyScale, 1f);
	}
}
