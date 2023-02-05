using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime��2/4/2023 5:28:57 PM
public partial class GenealogyForm : UIForm
{
	public GameObject Story, Item;
	private List<int> m_EndList = new List<int>() { 2001, 2003, 2003, 2006};
	private List<string> m_NameList = new List<string>() { "苏格拉底", "苏格拉底二世", "苏格拉底三世", "苏格拉底四世", };

    public override void Awake()
	{
		base.Awake();
		InitComponent();
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		if (PlayerPrefs.HasKey("curIndex"))
		{
			var curIndex = PlayerPrefs.GetInt("curIndex");
			for (int i=0; i<= curIndex; ++i)
            {
				m_EndList.Add(PlayerPrefs.GetInt(curIndex.ToString()));
			}
		}
        else
        {
			return;
        }

		GameObject story = null;
		HashSet<int> set = new HashSet<int>();
		for (int i = 0; i < m_EndList.Count; ++i)
		{
			if (i % 3 == 1 || i == 0)
			{
				story = Instantiate(Story, m_rectContent);
			}

			var id = m_EndList[i];
			var item = Instantiate(Item, story.transform);
			var path = GGJDataManager.Instance.GameSucceedIcoMap[id];
			var cg = item.transform.Find("m_cgBg").GetComponent<Image>();
			if (!set.Contains(id))
			{
				var p = "UI/cg/game_seccess_bg_0" + (id -2000).ToString();
				cg.sprite = Resources.Load<Sprite>(p);
			}
            else
            {
				cg.gameObject.SetActive(false);
			}

			string name;
			if (i <= 3)
            {
				name = m_NameList[i];
            }
            else
            {
				name = PlayerPrefs.GetString(id.ToString() + "name");
			}
			item.transform.Find("name/name/m_txtName").GetComponent<Text>().text = name;
			var img = item.transform.Find("name/name/m_imgBg").GetComponent<Image>();
			img.sprite = Resources.Load<Sprite>(path);

			set.Add(id);
		}
	}

    public override void Update()
    {
        base.Update();

		if (Input.GetKeyDown(KeyCode.Escape))
        {
			OnDestory();
        }
    }

    public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		
	}

	private void ReleaseEvent()
	{
		
	}


}

