using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime��2/4/2023 5:28:57 PM
public partial class GenealogyForm : UIForm
{
	public override void Awake()
	{
		base.Awake();
		//InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
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

