///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TickedTip : MonoBehaviour
{
	private void Start()
	{
		
	}

	public void InvokeTips(string[] tips)
	{
		if (tips == null || tips.Length == 0) return;
		
		TMP_Text txt = GetComponent<TMP_Text>();
		StartCoroutine(Disappear(txt, tips));
	}

	IEnumerator Disappear(TMP_Text txt, string[] tips)
	{
		Color curr = txt.color;
		Color invi = new Color(curr.r, curr.g, curr.b, 0f);
		
		for (int i = 0; i < tips.Length; i++)
		{
			txt.SetText(tips[i]);
			txt.DOColor(curr, 1.5f);
			yield return new WaitForSeconds(4.5f);
			txt.DOColor(invi, 2f);
			yield return new WaitForSeconds(2.2f);
		}
		
		Destroy(gameObject);
	}
}
