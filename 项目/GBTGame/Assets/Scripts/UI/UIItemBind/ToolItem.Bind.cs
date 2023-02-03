using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 20:51:17
public partial class ToolItem
{
	private AutoBind autoBind;
	private Text m_txtDes;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtDes = autoBind.itemList[0].obj.GetComponent<Text>();
	}
}

