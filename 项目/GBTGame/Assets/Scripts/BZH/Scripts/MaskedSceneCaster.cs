///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaskedSceneCaster : MonoBehaviour
{
	[SerializeField]
	private Image image;
	
	[SerializeField]
	private float maskDuration = 1.5f;

	[SerializeField]
	private Color targetColor;

	private string targetSceneName = "MainMenu";

	private void Start()
	{
		//StartCoroutine(BeginPlay());
	}

	IEnumerator BeginPlay(bool additive = false)
	{
		yield return new WaitForSeconds(0.1f);
		image.DOColor(targetColor, maskDuration);
		yield return new WaitForSeconds(maskDuration);

		yield return SceneManager.LoadSceneAsync(targetSceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
		if (additive)
		{
			Destroy(gameObject);
		}
	}

	public static IEnumerator CreateCast(string sceneName)
	{
		GameObject go = Resources.Load("P_MaskedSceneCaster", typeof(GameObject)) as GameObject;
		var inst = Instantiate(go, Vector3.zero, Quaternion.identity);
		MaskedSceneCaster caster = inst.GetComponentInChildren<MaskedSceneCaster>();
		caster.targetSceneName = sceneName;
		yield return new WaitForSeconds(0.15f);
		caster.StartCoroutine(caster.BeginPlay());
	}
	
	public static IEnumerator CreateCastAdditive(string sceneName)
	{
		GameObject go = Resources.Load("P_MaskedSceneCaster", typeof(GameObject)) as GameObject;
		var inst = Instantiate(go, Vector3.zero, Quaternion.identity);
		MaskedSceneCaster caster = inst.GetComponentInChildren<MaskedSceneCaster>();
		caster.targetSceneName = sceneName;
		yield return new WaitForSeconds(0.15f);
		caster.StartCoroutine(caster.BeginPlay(true));
	}
}
