using System.Collections;
using System.Collections.Generic;
using MyGameFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class UIForm : MonoBehaviour
{
    public AudioClip audioClip;

    public virtual void Awake()
    {

    }
    public virtual void OnOpen(System.Object obj)//����Ȩ����UISystem
    {
        if (audioClip != null)
        {
            SoundSystem.Instance.PlayMusic(audioClip.name);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void OnClose()//����Ȩ����UISystem
    {
        if (audioClip != null)
        {
            SoundSystem.Instance.StopMusic(audioClip.name);
        }
    }

    public virtual void OnDestory()
    {
        OnClose();
        Destroy(gameObject);
    }
}



