using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime��2/3/2023 9:55:11 PM
public partial class HandleForm
{
	private AutoBind autoBind;
	private RectTransform m_rect_arrow;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rect_arrow = autoBind.itemList[0].obj.GetComponent<RectTransform>();
	}
}

