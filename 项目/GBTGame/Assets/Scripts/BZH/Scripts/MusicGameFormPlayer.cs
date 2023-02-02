using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MusicGameFormPlayer : MonoBehaviour
{
	[SerializeField, DisplayName("音频")]
	private AudioClip realClip;

	private AudioSource source;

	private AudioSource backupSource;

	private Timer timer;

	[SerializeField, DisplayName("BPM")]
	private float bpm;

	[SerializeField, DisplayName("分子")]
	private sbyte molecule;

	[SerializeField, DisplayName("分母")]
	private sbyte deno;

	[SerializeField, DisplayName("播放延迟(毫秒)")]
	private float playDelay;

	[SerializeField, DisplayName("开始时播放")]
	private bool playOnStart;

	private float durationPerBeat;

	public float Bpm
	{
		get => bpm;
	}

	public sbyte Molecule
	{
		get => molecule;
	}

	public sbyte Deno
	{
		get => deno;
	}
	
	public float PlayDelayInSeconds
	{
		get => playDelay / 1000.0f;
	}

	public float DurationPerBeat
	{
		get => durationPerBeat;
	}

	public float Beat
	{
		get
		{
			float playTime = source.time - PlayDelayInSeconds;
			return (playTime / durationPerBeat) + 1.0f;
		}
	}

	public int Section
	{
		get => (int)((Beat - 1.0f) / molecule) + 1;
	}

	public float BeatInSection
	{
		get
		{
			/*float beat = Beat;
			int section = (int)((Beat - 1.0f) / molecule) + 1;
			return (int)(beat) % (section * molecule);*/
			float beat = Beat;
			int section = (int)((beat - 1.0f) / molecule);
			return beat - section * molecule;
		}
	}

	public MusicGameFormPlayer()
	{
		realClip = null;
		bpm = 100.0f;
		playDelay = 0.0f;
	}

	private void Awake()
	{
		durationPerBeat = 60.0f / bpm;
	}

	// Start is called before the first frame update
    void Start()
    {
	    var sources = GetComponents<AudioSource>();
	    source = sources[0];
	    backupSource = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
	    //Displayer.text = $"{Beat}\n{Section}\n{Section * molecule}\n{BeatInSection}";
    }

    public float ToPlayTime(float beat)
    {
	    return (beat - 1) * durationPerBeat;
    }

    public float ToLength(float beat)
    {
	    return beat * durationPerBeat;
    }

    public float ToPlayTime(int section, float beatInSection)
    {
	    return ToPlayTime((section - 1) * molecule + beatInSection);
    }

    public float ToPlayTime(int approachSection, float approachBeat, float beatLength)
    {
	    float deltaBeat = approachBeat - beatLength;
	    while (deltaBeat < 0.0f)
	    {
		    deltaBeat += molecule;
		    approachSection--;
	    }

	    //Debug.Log($"{approachSection}	{deltaBeat}");
	    return ToPlayTime(approachSection, deltaBeat);
    }

    public void Play()
    {
	    Debug.LogWarning("Play");
	    source.clip = realClip;
	    if (playDelay > 0.0f)
	    {
		    source.Play();
		    source.time = PlayDelayInSeconds;
	    }
	    else
	    {
		    source.PlayDelayed(PlayDelayInSeconds);
	    }
	    
	    //TimerManager.GetTimerManager().SetTimer(AddBomb, 0.0f, addEvent.BeginTime, 1L);
	    //TimerManager.GetTimerManager().SetTimer(AddBeat, durationPerBeat, 0.0f, 32L);
    }

    public void RevertTo(float beat)
    {
	    backupSource.clip = source.clip;
	    backupSource.time = source.time;
	    backupSource.volume = source.volume;
	    backupSource.Play();
	    backupSource.DOFade(0.0f, ToLength(0.5f));
	    source.time = PlayDelayInSeconds + ToPlayTime(beat);
    }
}
