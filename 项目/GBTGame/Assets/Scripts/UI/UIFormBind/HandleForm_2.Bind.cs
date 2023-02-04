using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/4 13:16:46
public partial class HandleForm_2
{
	private AutoBind autoBind;
	private Image m_imgbg;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_imgbg = autoBind.itemList[0].obj.GetComponent<Image>();
	}
}

