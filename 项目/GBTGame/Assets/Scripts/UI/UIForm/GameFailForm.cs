using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/4 14:53:36
public partial class GameFailForm : UIForm
{
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
	}

    public override void Update()
    {
        base.Update();

		if (Input.GetKeyDown(KeyCode.Return))
        {
			OnDestory();
		}
    }

    public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent();

		EventManagerSystem.Instance.Invoke("ChangeSateToStart");
	}

	private void RegisterEvent()
	{
		
	}

	private void ReleaseEvent()
	{
		
	}


}

