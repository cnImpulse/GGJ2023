using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    protected UIForm uiForm;//连接父物体
    public virtual void Awake()
    {
        
    }
    public virtual void OnOpen(System.Object obj)//控制权交给UISystem
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void OnClose()//控制权交给UISystem
    {

    }

    public virtual void SetParent(UIForm _uiForm)
    {
        uiForm = _uiForm;
    }
}
