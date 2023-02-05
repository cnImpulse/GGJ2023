using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/5 10:20:22
public partial class HUDForm
{
	private AutoBind autoBind;
	private RectTransform m_rectLevelDes;
	private Scrollbar m_scrollbarOxygen;
	private Image m_imgOxyLim;
	private Scrollbar m_scrollbarWater;
	private Image m_imgWaterLim;
	private Scrollbar m_scrollbarFertilizer;
	private Image m_imgFerLim;
	private RectTransform m_rectTipDes;
	private Button m_btnFunc;
	private Text m_txtFuncDes;
	private Image m_imgFuncimg;
	private Image m_imgFuncBoom;
	private Image m_imgFunciStop;
	private Image m_imgFuncAddSpeed;
	private Image m_imgFuncPause;
	private Text m_txtFen;
	private Text m_txtSec;
	private Text m_txtLevel;
	private Text m_txtCutDown;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rectLevelDes = autoBind.itemList[0].obj.GetComponent<RectTransform>();
		m_scrollbarOxygen = autoBind.itemList[1].obj.GetComponent<Scrollbar>();
		m_imgOxyLim = autoBind.itemList[2].obj.GetComponent<Image>();
		m_scrollbarWater = autoBind.itemList[3].obj.GetComponent<Scrollbar>();
		m_imgWaterLim = autoBind.itemList[4].obj.GetComponent<Image>();
		m_scrollbarFertilizer = autoBind.itemList[5].obj.GetComponent<Scrollbar>();
		m_imgFerLim = autoBind.itemList[6].obj.GetComponent<Image>();
		m_rectTipDes = autoBind.itemList[7].obj.GetComponent<RectTransform>();
		m_btnFunc = autoBind.itemList[8].obj.GetComponent<Button>();
		m_txtFuncDes = autoBind.itemList[9].obj.GetComponent<Text>();
		m_imgFuncimg = autoBind.itemList[10].obj.GetComponent<Image>();
		m_imgFuncBoom = autoBind.itemList[11].obj.GetComponent<Image>();
		m_imgFunciStop = autoBind.itemList[12].obj.GetComponent<Image>();
		m_imgFuncAddSpeed = autoBind.itemList[13].obj.GetComponent<Image>();
		m_imgFuncPause = autoBind.itemList[14].obj.GetComponent<Image>();
		m_txtFen = autoBind.itemList[15].obj.GetComponent<Text>();
		m_txtSec = autoBind.itemList[16].obj.GetComponent<Text>();
		m_txtLevel = autoBind.itemList[17].obj.GetComponent<Text>();
		m_txtCutDown = autoBind.itemList[18].obj.GetComponent<Text>();
	}
}

