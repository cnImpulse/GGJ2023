using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 16:36:11
public partial class AllGameOverForm
{
	private AutoBind autoBind;
	private Text m_txtDes;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtDes = autoBind.itemList[0].obj.GetComponent<Text>();
	}
}

