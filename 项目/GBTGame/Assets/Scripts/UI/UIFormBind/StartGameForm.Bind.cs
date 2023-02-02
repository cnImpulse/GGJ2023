using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 11:24:03
public partial class StartGameForm
{
	private AutoBind autoBind;
	private Button m_btnStart;
	private Button m_btnDeveloper;
	private Button m_btnExit;
	private Button m_btnHelper;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnStart = autoBind.itemList[0].obj.GetComponent<Button>();
		m_btnDeveloper = autoBind.itemList[1].obj.GetComponent<Button>();
		m_btnExit = autoBind.itemList[2].obj.GetComponent<Button>();
		m_btnHelper = autoBind.itemList[3].obj.GetComponent<Button>();
	}
}

