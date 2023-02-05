using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime��2/5/2023 10:46:11 AM
public partial class GenealogyForm
{
	private AutoBind autoBind;
	private RectTransform m_rectContent;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rectContent = autoBind.itemList[0].obj.GetComponent<RectTransform>();
	}
}

