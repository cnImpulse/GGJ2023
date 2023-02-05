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
	private int m_curIndex = 0;

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		m_curIndex = 0;
		if (PlayerPrefs.HasKey("curIndex"))
        {
			m_curIndex = PlayerPrefs.GetInt("curIndex");
			m_curIndex++;
		}

		PlayerPrefs.SetInt(m_curIndex.ToString(), GGJDataManager.Instance.SucceedId);
		PlayerPrefs.SetInt("curIndex", m_curIndex);

		var p = "UI/cg/game_seccess_bg_0" + (GGJDataManager.Instance.SucceedId - 2000).ToString();
		//cg.sprite = Resources.Load<Sprite>(p);
	}

	public override void Update()
	{
		base.Update();

		if (Input.GetKeyDown(KeyCode.Return))
		{
			name = m_inputLable.text;
			PlayerPrefs.SetString(m_curIndex.ToString() + "name", name);

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

