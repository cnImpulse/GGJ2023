using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using DataCs;

//CreateTime：2022/11/6 9:37:18

public class SkillFormStruct
{
	public int LastSkill;
	public int attackSkill;
	public int defenseSkill;
	public int attackSkillSpeed;

	public SkillFormStruct(int lastSkill, int attackSkill, int defenseSkill, int attackSkillSpeed)
	{
		LastSkill = lastSkill;
		this.attackSkill = attackSkill;
		this.defenseSkill = defenseSkill;
		this.attackSkillSpeed = attackSkillSpeed;
	}
}

public partial class SkillTreeForm : UIForm
{
    private int LastSkill;
    private int attackSkill;
    private int defenseSkill;
    private int attackSkillSpeed;

    public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		SkillFormStruct temp = (SkillFormStruct)obj;
        LastSkill = temp.LastSkill;
        attackSkill = temp.attackSkill;
        defenseSkill = temp.defenseSkill;
        attackSkillSpeed = temp.attackSkillSpeed;
        UpdateDate();

    }

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnDefence.onClick.AddListener(OnBtnDefence);
		m_btnAttack.onClick.AddListener(OnBtnAttack);
		m_btnAttackSpeed.onClick.AddListener(OnBtnAttackSpeed);
		m_btnDefenceAdd.onClick.AddListener(OnBtnDefenceAdd);
		m_btnAttackAdd.onClick.AddListener(OnBtnAttackAdd);
		m_btnAttackSpeedAdd.onClick.AddListener(OnBtnAttackSpeedAdd);
        m_btnBack.onClick.AddListener(OnBack);
    }

	private void ReleaseEvent()
	{
		m_btnDefence.onClick.RemoveListener(OnBtnDefence);
		m_btnAttack.onClick.RemoveListener(OnBtnAttack);
		m_btnAttackSpeed.onClick.RemoveListener(OnBtnAttackSpeed);
		m_btnDefenceAdd.onClick.RemoveListener(OnBtnDefenceAdd);
		m_btnAttackAdd.onClick.RemoveListener(OnBtnAttackAdd);
		m_btnAttackSpeedAdd.onClick.RemoveListener(OnBtnAttackSpeedAdd);
        m_btnBack.onClick.RemoveListener(OnBack);
    }

	private void OnBtnDefence()
	{
		if (LastSkill > 0)
		{
			LastSkill--;
			defenseSkill++;
        }
		UpdateDate();
		SaveData();
    }
	private void OnBtnAttack()
	{
        if (LastSkill > 0)
        {
            LastSkill--;
            attackSkill++;
        }
		UpdateDate();
		SaveData();
    }
	private void OnBtnAttackSpeed()
	{
        if (LastSkill > 0)
        {
            LastSkill--;
            attackSkillSpeed++;
        }
		UpdateDate();
		SaveData();
    }
	private void OnBtnDefenceAdd()
	{
		OnBtnDefence();

    }
	private void OnBtnAttackAdd()
	{
		OnBtnAttack();

    }
	private void OnBtnAttackSpeedAdd()
	{
		OnBtnAttackSpeed();
    }

	private void UpdateDate()
	{
		m_txtLastSkill.text = LastSkill.ToString();
		m_txtDefence.text = defenseSkill.ToString();
		m_txtAttack.text = attackSkill.ToString();
		m_txtAttackSpeed.text = attackSkillSpeed.ToString();
	}

	private void OnBack()
	{
		EventManagerSystem.Instance.Invoke2(Data_EventName.BackMenu_str,BackMenuEventArgs.Create());
        UISystem.Instance.CloseUIForm(Data_UIFormID.key_SkillForm, this);
    }

	private void SaveData()
	{
		EventManagerSystem.Instance.Invoke2(Data_EventName.SaveSkill_str, SaveSkillEventArgs.Create(LastSkill, defenseSkill, attackSkill, attackSkillSpeed));
	}

}

