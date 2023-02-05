using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/5 13:26:54
public partial class DebugPanel
{
	private AutoBind autoBind;
	private Text m_txtDebug;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtDebug = autoBind.itemList[0].obj.GetComponent<Text>();
	}
}

