using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 10:15:22
public partial class SkillTreeForm
{
	private AutoBind autoBind;
	private Text m_txtLastSkill;
	private Button m_btnDefence;
	private Text m_txtDefence;
	private Button m_btnAttack;
	private Text m_txtAttack;
	private Button m_btnAttackSpeed;
	private Text m_txtAttackSpeed;
	private Button m_btnDefenceAdd;
	private Button m_btnAttackAdd;
	private Button m_btnAttackSpeedAdd;
	private Button m_btnBack;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtLastSkill = autoBind.itemList[0].obj.GetComponent<Text>();
		m_btnDefence = autoBind.itemList[1].obj.GetComponent<Button>();
		m_txtDefence = autoBind.itemList[2].obj.GetComponent<Text>();
		m_btnAttack = autoBind.itemList[3].obj.GetComponent<Button>();
		m_txtAttack = autoBind.itemList[4].obj.GetComponent<Text>();
		m_btnAttackSpeed = autoBind.itemList[5].obj.GetComponent<Button>();
		m_txtAttackSpeed = autoBind.itemList[6].obj.GetComponent<Text>();
		m_btnDefenceAdd = autoBind.itemList[7].obj.GetComponent<Button>();
		m_btnAttackAdd = autoBind.itemList[8].obj.GetComponent<Button>();
		m_btnAttackSpeedAdd = autoBind.itemList[9].obj.GetComponent<Button>();
		m_btnBack = autoBind.itemList[10].obj.GetComponent<Button>();
	}
}

