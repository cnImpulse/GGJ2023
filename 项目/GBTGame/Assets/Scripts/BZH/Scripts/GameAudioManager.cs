///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameAudioManager : MonoBehaviour
{
	public static GameAudioManager Instance;

	[SerializeField]
	private AudioMixer masterMixer;
	
    public GameAudioManager()
    {
        
    }

    private void Awake()
    {
	    if (Instance)
	    {
		    return;
	    }
	    
	    DontDestroyOnLoad(gameObject);
	    Instance = this;
    }

    private void Start()
    {
	    PlayerOptions playerOptions = PlayerOptions.SafeLoadSettings();
	    SetMasterVolume(playerOptions.MasterVolume);
	    SetMusicVolume(playerOptions.MusicVolume);
	    SetAffectVolume(playerOptions.AffectVolume);
    }

    public void SetMasterVolume(float value)
    {
	    masterMixer.SetFloat("MasterVolume", GetVolume(value));
    }
    
    public void SetMusicVolume(float value)
    {
	    masterMixer.SetFloat("MusicVolume", GetVolume(value));
    }
    
    public void SetAffectVolume(float value)
    {
	    masterMixer.SetFloat("AffectVolume", GetVolume(value));
    }

    private float GetVolume(float value)
    {
	    return 17.334f * Mathf.Log(value + 1f) - 80f;
    }
}
