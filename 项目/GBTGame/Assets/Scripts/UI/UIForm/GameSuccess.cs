using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime��2/4/2023 4:42:12 PM
public partial class GameSuccess : UIForm
{
	public string name;
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		int curIndex = 0;
		if (PlayerPrefs.HasKey("curIndex"))
        {
			curIndex = PlayerPrefs.GetInt("curIndex");
			curIndex++;
		}

		PlayerPrefs.SetInt(curIndex.ToString(), GGJDataManager.Instance.SucceedId);
		PlayerPrefs.SetInt("curIndex", curIndex);
	}

	public override void Update()
	{
		base.Update();

		if (Input.GetKeyDown(KeyCode.Return))
		{
			name = m_inputLable.text;
            
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

