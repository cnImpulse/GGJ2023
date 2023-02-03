using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 21:16:03
public partial class ToolForm
{
	private AutoBind autoBind;
	public RectTransform m_rectPanel;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rectPanel = autoBind.itemList[0].obj.GetComponent<RectTransform>();
	}
}

