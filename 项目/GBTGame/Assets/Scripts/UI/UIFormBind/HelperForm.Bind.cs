using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/11/6 17:28:12
public partial class HelperForm
{
	private AutoBind autoBind;
	private RectTransform m_rect0;
	private Text m_txtDes0;
	private RectTransform m_rect1;
	private Text m_txtDes1;
	private RectTransform m_rect2;
	private Text m_txtDes2;
	private RectTransform m_rect3;
	private Text m_txtDes3;
	private RectTransform m_rect4;
	private Text m_txtDes4;
	private RectTransform m_rect5;
	private Text m_txtDes5;
	private RectTransform m_rect6;
	private Text m_txtDes6;
	private RectTransform m_rect7;
	private Text m_txtDes7;
	private Button m_btnClose;
	private Button m_btnUp;
	private Button m_btnDown;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rect0 = autoBind.itemList[0].obj.GetComponent<RectTransform>();
		m_txtDes0 = autoBind.itemList[1].obj.GetComponent<Text>();
		m_rect1 = autoBind.itemList[2].obj.GetComponent<RectTransform>();
		m_txtDes1 = autoBind.itemList[3].obj.GetComponent<Text>();
		m_rect2 = autoBind.itemList[4].obj.GetComponent<RectTransform>();
		m_txtDes2 = autoBind.itemList[5].obj.GetComponent<Text>();
		m_rect3 = autoBind.itemList[6].obj.GetComponent<RectTransform>();
		m_txtDes3 = autoBind.itemList[7].obj.GetComponent<Text>();
		m_rect4 = autoBind.itemList[8].obj.GetComponent<RectTransform>();
		m_txtDes4 = autoBind.itemList[9].obj.GetComponent<Text>();
		m_rect5 = autoBind.itemList[10].obj.GetComponent<RectTransform>();
		m_txtDes5 = autoBind.itemList[11].obj.GetComponent<Text>();
		m_rect6 = autoBind.itemList[12].obj.GetComponent<RectTransform>();
		m_txtDes6 = autoBind.itemList[13].obj.GetComponent<Text>();
		m_rect7 = autoBind.itemList[14].obj.GetComponent<RectTransform>();
		m_txtDes7 = autoBind.itemList[15].obj.GetComponent<Text>();
		m_btnClose = autoBind.itemList[16].obj.GetComponent<Button>();
		m_btnUp = autoBind.itemList[17].obj.GetComponent<Button>();
		m_btnDown = autoBind.itemList[18].obj.GetComponent<Button>();
	}
}

