///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToScreenAdaption : MonoBehaviour
{
	public SpriteToScreenAdaption()
    {
        
    }

	private void Awake()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		Camera mainCamera = Camera.main;

		spriteRenderer.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z);
		spriteRenderer.transform.localScale = new Vector3(100f, 100f, 1f);
	}
}
