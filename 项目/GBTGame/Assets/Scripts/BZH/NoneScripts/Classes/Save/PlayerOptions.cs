///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptions : Slot
{
	public float MasterVolume;

	public float MusicVolume;

	public float AffectVolume;
	
    public PlayerOptions(float masterVolume, float musicVolume, float affectVolume)
    {
	    MasterVolume = masterVolume;
	    MusicVolume = musicVolume;
	    AffectVolume = affectVolume;
    }

    public static string SlotName
    {
	    get => "PlayerSettings";
    }

    public static PlayerOptions SafeLoadSettings()
    {
	    if (Slot.TryLoadGameFromNative(out PlayerOptions ps, SlotName) == false)
	    {
		    ps = new PlayerOptions(100f, 100f, 100f);
		    Slot.SaveGameToNative(ps, SlotName);
	    }

	    return ps;
    }
}
