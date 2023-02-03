using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 19:07:19
public partial class TestPanel
{
	private AutoBind autoBind;
	private Button m_btnOK;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnOK = autoBind.itemList[0].obj.GetComponent<Button>();
	}
}

