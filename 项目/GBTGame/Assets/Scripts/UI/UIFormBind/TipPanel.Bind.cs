using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/5 14:30:51
public partial class TipPanel
{
	private AutoBind autoBind;
	private Button m_btnClose;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnClose = autoBind.itemList[0].obj.GetComponent<Button>();
	}
}

