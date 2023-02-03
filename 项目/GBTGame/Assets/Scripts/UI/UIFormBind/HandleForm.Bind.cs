using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 19:39:36
public partial class HandleForm
{
	private AutoBind autoBind;
	private Image m_imgHandle;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_imgHandle = autoBind.itemList[0].obj.GetComponent<Image>();
	}
}

