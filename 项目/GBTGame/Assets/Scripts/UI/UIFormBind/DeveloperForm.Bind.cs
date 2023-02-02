using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/1 16:22:51
public partial class DeveloperForm
{
	private AutoBind autoBind;
	private Text m_txtIntroduce;
	private Button m_btnBack;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_txtIntroduce = autoBind.itemList[0].obj.GetComponent<Text>();
		m_btnBack = autoBind.itemList[1].obj.GetComponent<Button>();
	}
}

