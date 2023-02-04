using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime��2/4/2023 4:42:12 PM
public partial class GameSuccess
{
	private AutoBind autoBind;
	private Image m_imgBg;
	private Text m_txtInput;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_imgBg = autoBind.itemList[0].obj.GetComponent<Image>();
		m_txtInput = autoBind.itemList[1].obj.GetComponent<Text>();
	}
}

