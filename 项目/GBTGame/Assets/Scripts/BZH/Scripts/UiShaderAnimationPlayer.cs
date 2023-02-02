using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiShaderAnimationPlayer : MonoBehaviour
{
	[SerializeField, DisplayName("目标图片渲染器")]
	private Image targetImage;

	[SerializeField, DisplayName("属性的名字(省略前置下划线)")]
	private string propertyName;

	[SerializeField, DisplayName("播放持续时间")]
	private float animationDuration;

	[SerializeField, DisplayName("播放方式")]
	private AnimationPlayMode playMode;
	
	[SerializeField, DisplayName("结束事件触发延时")]
	private float disappearDuration;
	
	[SerializeField, DisplayName("需要销毁？")]
	private bool shouldDisappear;

	[SerializeField, Space(30f)]
	private UnityEvent onEnable;
	
	[SerializeField]
	private UnityEvent onEnd;
	
	private int propertyCode;

	private float playSpeed;

	private float bar;

	private Timer destroyTimer;

	public float PlaySpeed
	{
		set => playSpeed = Mathf.Clamp(value, 0f, 999f);
	}

	public float DisappearDuration
	{
		set => disappearDuration = Mathf.Clamp(value, 0f, 999f);
	}

	public UiShaderAnimationPlayer()
	{
		propertyName = "MainTex";
		animationDuration = 1f;
		playMode = AnimationPlayMode.Sequence;
		shouldDisappear = true;
		disappearDuration = 0.1f;
		bar = 0f;
		onEnable = new UnityEvent();
		onEnd = new UnityEvent();
	}

	private void Awake()
	{
		propertyCode = Shader.PropertyToID("_" + propertyName);
		playSpeed = 1f / animationDuration;
	}

	private void OnEnable()
	{
		onEnable.Invoke();
		if (playMode == AnimationPlayMode.Reverse)
		{
			bar = 1f;
			playSpeed *= -1f;
		}
	    
		targetImage.material.SetFloat(propertyCode, bar);
		InvokePlay();
	}

	void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
	    bar = Mathf.Clamp01(bar + Time.deltaTime * playSpeed);
	    targetImage.material.SetFloat(propertyCode, bar);
    }

    void OnTimeSpanEnd()
    {
	    onEnd.Invoke();
	    if (shouldDisappear)
			Destroy(gameObject);
    }

    private float relativeDuration
    {
	    get => (playMode == AnimationPlayMode.Sequence ? bar : 1f - bar) * animationDuration;
    }

    void InvokePlay()
    {
	    TimerManager manager = TimerManager.GetTimerManager();
	    if (destroyTimer != null) manager.ClearTimer(destroyTimer);
	    destroyTimer = manager.SetTimer(OnTimeSpanEnd, 0f, disappearDuration + animationDuration - relativeDuration, 1);
    }

    public void ReverseMode(bool disappear = true)
    {
	    playMode = (playMode == AnimationPlayMode.Sequence ? AnimationPlayMode.Reverse : AnimationPlayMode.Sequence);
	    playSpeed *= -1f;
	    shouldDisappear = disappear;
	    InvokePlay();
    }

    public void ReverseMode(float dd)
    {
	    disappearDuration = dd;
	    ReverseMode();
    }
}
