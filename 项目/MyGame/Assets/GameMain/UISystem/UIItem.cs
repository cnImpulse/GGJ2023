using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    protected UIForm uiForm;//���Ӹ�����
    public virtual void Awake()
    {
        
    }
    public virtual void OnOpen(System.Object obj)//����Ȩ����UISystem
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void OnClose()//����Ȩ����UISystem
    {

    }

    public virtual void SetParent(UIForm _uiForm)
    {
        uiForm = _uiForm;
    }
}
