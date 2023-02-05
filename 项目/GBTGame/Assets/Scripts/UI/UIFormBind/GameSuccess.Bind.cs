using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/5 14:57:05
public partial class GameSuccess
{
	private AutoBind autoBind;
	private Image m_imgBg;
	private Text m_txtInput;
	private InputField m_inputLable;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_imgBg = autoBind.itemList[0].obj.GetComponent<Image>();
		m_txtInput = autoBind.itemList[1].obj.GetComponent<Text>();
		m_inputLable = autoBind.itemList[2].obj.GetComponent<InputField>();
	}
}

