using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;


public class MainFormStruct
{
	public float MaxTowerHp;
	public int level;
	public int curr_exp;
	public MainFormStruct(float MaxTowerHp, int level, int curr_exp)
	{
		this.MaxTowerHp = MaxTowerHp;
		this.level = level;
		this.curr_exp = curr_exp;
	}
}

//CreateTime：2022/11/5 9:14:01
public partial class MainForm : UIForm
{
    float PlayerHp;
    float CurrPlayerHp;

	float MainTowerHp;
	float CurrMainTowerHp;

	float MaxX;
	float MinX;

	float MaxTowerY;
	float MinTowerY;

	int level;
	int curr_exp;


    public override void Awake()
	{
		base.Awake();
		InitComponent();
        EventManagerSystem.Instance.Add2(Data_EventName.PlayerInjure_str, PlayerInjure);
        EventManagerSystem.Instance.Add2(Data_EventName.GameOver_str, GameOver);
        EventManagerSystem.Instance.Add2(Data_EventName.GameOK_str, GameOK);
        EventManagerSystem.Instance.Add2(Data_EventName.MainTowerInjure_str, MainTowerInjure);
        EventManagerSystem.Instance.Add2(Data_EventName.AddExp_str, AddExp);
    }

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		MaxX = 985f;
		MinX = 720f;

		MaxTowerY = 377f;
		MinTowerY = 129f;

        RegisterEvent();
        PlayerHp = TOOLS.GetPlayerMaxHp();
        CurrPlayerHp = PlayerData.GetDefaultObject().InitialHp;
		MainFormStruct temp = (MainFormStruct)obj;
        MainTowerHp = temp.MaxTowerHp;
		level = temp.level;
		curr_exp = temp.curr_exp;
        int max_exp = TOOLS.GetRequiredExp(level);

        m_txtCurrExp.text = curr_exp.ToString() + "/" + max_exp.ToString();
        m_txtCurrLevel.text = level.ToString();

        CurrMainTowerHp = MainTowerHp;


		//m_scrollbarInjure.value = 1f;
		//m_scrollbarInjure.size = CurrPlayerHp / PlayerHp;
		SetTowerHp(1F);
        SetHp(CurrPlayerHp / PlayerHp);
        m_txtHP.text = ((int)CurrPlayerHp).ToString();
        m_txtTowerHP.text = ((int)CurrMainTowerHp).ToString();
    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		
    }

	private void ReleaseEvent()
	{
        //EventManagerSystem.Instance.Delete2(Data_EventName.PlayerInjure_str, PlayerInjure);
        //EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver);
        //EventManagerSystem.Instance.Delete2(Data_EventName.GameOK_str, GameOK);
        //EventManagerSystem.Instance.Delete2(Data_EventName.MainTowerInjure_str, MainTowerInjure);
        //EventManagerSystem.Instance.Delete2(Data_EventName.AddExp_str, AddExp);
    }

	void PlayerInjure(IEventArgs eventArgs)
	{
		PlayerInjureEventArgs playerInjureEventArgs = eventArgs as PlayerInjureEventArgs;

		CurrPlayerHp -= playerInjureEventArgs.DPS;

		if (CurrPlayerHp <= 0)
		{
			CurrPlayerHp = 0;
        }
		if (CurrPlayerHp >= PlayerHp)
		{
			CurrPlayerHp = PlayerHp;

        }

		//m_scrollbarInjure.size = CurrPlayerHp / PlayerHp;
		SetHp(CurrPlayerHp / PlayerHp);
        m_txtHP.text = ((int)CurrPlayerHp).ToString();
		//m_scrollbarInjure.value = 1f;
    }

	void AddExp(IEventArgs eventArgs)
	{
		AddExpEventArgs addExpEventArgs = eventArgs as AddExpEventArgs;
		int exp = addExpEventArgs.exp;

		int max_exp = TOOLS.GetRequiredExp(level);

        if (exp + curr_exp >= max_exp)
        {
            level++;
			curr_exp = exp + curr_exp - max_exp;

        }
		else
		{
			curr_exp += exp;

        }

        max_exp = TOOLS.GetRequiredExp(level);

        while (curr_exp >= max_exp)
		{
			level++;
			curr_exp -= max_exp;
            max_exp = TOOLS.GetRequiredExp(level);
        }

		m_txtCurrExp.text = curr_exp.ToString() + "/" + max_exp.ToString();
		m_txtCurrLevel.text = level.ToString();

	}

	void MainTowerInjure(IEventArgs eventArgs)
	{
		

		MainTowerInjureEventArgs mainTowerInjureEventArgs = (MainTowerInjureEventArgs)eventArgs;
		float DPS = mainTowerInjureEventArgs.DPS;
        //Debug.Log("TowerInjure:"+DPS.ToString());

        CurrMainTowerHp -= DPS;

        if (CurrMainTowerHp <= 0)
        {
            CurrMainTowerHp = 0;
        }
        if (CurrMainTowerHp >= MainTowerHp)
        {
            CurrMainTowerHp = MainTowerHp;

        }
        //m_scrollbarInjure.size = CurrPlayerHp / PlayerHp;
        SetTowerHp(CurrMainTowerHp / MainTowerHp);
        m_txtTowerHP.text = ((int)CurrMainTowerHp).ToString();
        //m_scrollbarInjure.value = 1f;
    }

    void GameOver(IEventArgs eventArgs)
    {
		UISystem.Instance.CloseUIForm(Data_UIFormID.key_MainForm, this);
    }

    void GameOK(IEventArgs eventArgs)
    {
        
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_MainForm, this);
    }

	void SetHp(float pre)
	{
		Vector3 temp = m_imgSubImg.rectTransform.anchoredPosition;
		temp.x = pre * (MaxX - MinX) + MinX;
		m_imgSubImg.rectTransform.anchoredPosition = temp;

    }

	void SetTowerHp(float pre)
	{
        Vector3 temp = m_imgTowerSubImg.rectTransform.anchoredPosition;
        temp.y = pre * (MaxTowerY - MinTowerY) + MinTowerY;
        m_imgTowerSubImg.rectTransform.anchoredPosition = temp;
    }
}

