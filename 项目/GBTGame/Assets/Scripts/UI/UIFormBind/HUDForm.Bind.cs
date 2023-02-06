using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/5 15:38:37
public partial class HUDForm
{
	private AutoBind autoBind;
	private RectTransform m_rectToolPanel;
	private Button m_btnFunc;
	private Text m_txtToolName;
	private Text m_txtFuncDes;
	private Image m_imgFuncimg;
	private Image m_imgFuncBoom;
	private Image m_imgFunciStop;
	private Image m_imgFuncAddSpeed;
	private Image m_imgFuncPause;
	private Image m_imgFuncRefresh;
	private Image m_imgLevel1;
	private Image m_imgLevel2;
	private Image m_imgLevel3;
	private Text m_txtFen;
	private Text m_txtSec;
	private RectTransform m_rectLevelDes;
	private Scrollbar m_scrollbarOxygen;
	private Image m_imgOxyLim;
	private Image m_imgOxyRed;
	private Scrollbar m_scrollbarWater;
	private Image m_imgWaterLim;
	private Image m_imgWaterRed;
	private Scrollbar m_scrollbarFertilizer;
	private Image m_imgFerLim;
	private Image m_imgFerRed;
	private RectTransform m_recttipbg;
	private Text m_txtLevel;
	private Text m_txtCutDown;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rectToolPanel = autoBind.itemList[0].obj.GetComponent<RectTransform>();
		m_btnFunc = autoBind.itemList[1].obj.GetComponent<Button>();
		m_txtToolName = autoBind.itemList[2].obj.GetComponent<Text>();
		m_txtFuncDes = autoBind.itemList[3].obj.GetComponent<Text>();
		m_imgFuncimg = autoBind.itemList[4].obj.GetComponent<Image>();
		m_imgFuncBoom = autoBind.itemList[5].obj.GetComponent<Image>();
		m_imgFunciStop = autoBind.itemList[6].obj.GetComponent<Image>();
		m_imgFuncAddSpeed = autoBind.itemList[7].obj.GetComponent<Image>();
		m_imgFuncPause = autoBind.itemList[8].obj.GetComponent<Image>();
		m_imgFuncRefresh = autoBind.itemList[9].obj.GetComponent<Image>();
		m_imgLevel1 = autoBind.itemList[10].obj.GetComponent<Image>();
		m_imgLevel2 = autoBind.itemList[11].obj.GetComponent<Image>();
		m_imgLevel3 = autoBind.itemList[12].obj.GetComponent<Image>();
		m_txtFen = autoBind.itemList[13].obj.GetComponent<Text>();
		m_txtSec = autoBind.itemList[14].obj.GetComponent<Text>();
		m_rectLevelDes = autoBind.itemList[15].obj.GetComponent<RectTransform>();
		m_scrollbarOxygen = autoBind.itemList[16].obj.GetComponent<Scrollbar>();
		m_imgOxyLim = autoBind.itemList[17].obj.GetComponent<Image>();
		m_imgOxyRed = autoBind.itemList[18].obj.GetComponent<Image>();
		m_scrollbarWater = autoBind.itemList[19].obj.GetComponent<Scrollbar>();
		m_imgWaterLim = autoBind.itemList[20].obj.GetComponent<Image>();
		m_imgWaterRed = autoBind.itemList[21].obj.GetComponent<Image>();
		m_scrollbarFertilizer = autoBind.itemList[22].obj.GetComponent<Scrollbar>();
		m_imgFerLim = autoBind.itemList[23].obj.GetComponent<Image>();
		m_imgFerRed = autoBind.itemList[24].obj.GetComponent<Image>();
		m_recttipbg = autoBind.itemList[25].obj.GetComponent<RectTransform>();
		m_txtLevel = autoBind.itemList[26].obj.GetComponent<Text>();
		m_txtCutDown = autoBind.itemList[27].obj.GetComponent<Text>();
	}
}

