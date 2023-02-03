using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/4 0:00:46
public partial class HUDForm
{
	private AutoBind autoBind;
	private RectTransform m_rectLevelDes;
	private Scrollbar m_scrollbarFertilizer;
	private Scrollbar m_scrollbarOxygen;
	private Scrollbar m_scrollbarWater;
	private RectTransform m_rectTipDes;
	private Button m_btnFunc;
	private Image m_imgFuncimg;
	private Text m_txtFuncDes;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rectLevelDes = autoBind.itemList[0].obj.GetComponent<RectTransform>();
		m_scrollbarFertilizer = autoBind.itemList[1].obj.GetComponent<Scrollbar>();
		m_scrollbarOxygen = autoBind.itemList[2].obj.GetComponent<Scrollbar>();
		m_scrollbarWater = autoBind.itemList[3].obj.GetComponent<Scrollbar>();
		m_rectTipDes = autoBind.itemList[4].obj.GetComponent<RectTransform>();
		m_btnFunc = autoBind.itemList[5].obj.GetComponent<Button>();
		m_imgFuncimg = autoBind.itemList[6].obj.GetComponent<Image>();
		m_txtFuncDes = autoBind.itemList[7].obj.GetComponent<Text>();
	}
}

