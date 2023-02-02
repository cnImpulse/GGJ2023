///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class RandomBGMPlayer : MonoBehaviour
{
	[SerializeField, DisplayName("背景音乐列表")]
	private AudioClip[] bgms;

	[SerializeField, Min(0f), DisplayName("播放延时")]
	private float delayToPlay;

	private AudioSource source;

	public RandomBGMPlayer()
	{
		delayToPlay = 0.5f;
	}

	private void Start()
	{
		source = GetComponent<AudioSource>();
		Debug.Assert(source, $"没有在RandomBGMPlayer{gameObject.name}上找到AudioSource。");
		if (bgms.Length != 0)
		{
			Invoke("Play", delayToPlay);
		}
	}

	public void Play()
	{
		int rand = Mathf.FloorToInt(Random.Range(0f, bgms.Length));
		source.clip = bgms[rand];
		source.Play();
	}

	public void AddClips(params AudioClip[] clips)
	{
		if (clips == null || clips.Length == 0) return;
		
		int oriLength = bgms.Length;
		int clipLength = clips.Length;
		Array.Resize(ref bgms, oriLength + clipLength);
		for (int i = 0; i < clipLength; i++)
		{
			bgms[oriLength + i] = clips[i];
		}
	}
}
