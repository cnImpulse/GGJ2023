using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/4 14:53:36
public partial class GameFailForm
{
	private AutoBind autoBind;
	private Text m_txtInput;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtInput = autoBind.itemList[0].obj.GetComponent<Text>();
	}
}

