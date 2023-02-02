using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 16:19:56
public partial class AllGameStartForm
{
	private AutoBind autoBind;
	private Text m_txtDes;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtDes = autoBind.itemList[0].obj.GetComponent<Text>();
	}
}

