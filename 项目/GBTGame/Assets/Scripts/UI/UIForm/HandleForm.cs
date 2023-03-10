using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2023/2/3 19:39:36
public partial class HandleForm : UIForm
{
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);

		GGJDataManager.Instance.Rect = transform.Find("rect") as RectTransform;
		GGJDataManager.Instance.Rect2 = transform.Find("rect2") as RectTransform;

		RegisterEvent();
	}

    public override void Update()
    {
        base.Update();


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

