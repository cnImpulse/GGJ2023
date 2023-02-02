using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/5 10:30:12
public partial class MenuForm
{
	private AutoBind autoBind;
	private Button m_btnLevel1;
	private Button m_btnLevel2;
	private Button m_btnLevel3;
	private Button m_btnBack;
	private Button m_btnSkillTree;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnLevel1 = autoBind.itemList[0].obj.GetComponent<Button>();
		m_btnLevel2 = autoBind.itemList[1].obj.GetComponent<Button>();
		m_btnLevel3 = autoBind.itemList[2].obj.GetComponent<Button>();
		m_btnBack = autoBind.itemList[3].obj.GetComponent<Button>();
		m_btnSkillTree = autoBind.itemList[4].obj.GetComponent<Button>();
	}
}

