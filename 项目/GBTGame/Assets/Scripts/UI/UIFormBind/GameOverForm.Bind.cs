using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 0:19:30
public partial class GameOverForm
{
	private AutoBind autoBind;
	private Button m_btnOK;
	private Button m_btnNext;
	private Button m_btnReTry;
	private Text m_txtDeadDic;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnOK = autoBind.itemList[0].obj.GetComponent<Button>();
		m_btnNext = autoBind.itemList[1].obj.GetComponent<Button>();
		m_btnReTry = autoBind.itemList[2].obj.GetComponent<Button>();
		m_txtDeadDic = autoBind.itemList[3].obj.GetComponent<Text>();
	}
}

