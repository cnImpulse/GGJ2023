using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHpBar : MonoBehaviour
{
    public Image m_imgSubimg;

    float MaxX;
    float MinX;

    float MaxHp;
    float CurrHp;

    bool isDestory;
    
    private void Start()
    {
        MaxX = 212f;
        MinX = 87f;
        SetHp(1f);
        isDestory = false;
    }

    public void Injure(float DPS)
    {
        //Debug.Log("TowerInjure:"+DPS.ToString());

        CurrHp -= DPS;

        if (CurrHp <= 0)
        {
            CurrHp = 0;
        }
        if (CurrHp >= MaxHp)
        {
            CurrHp = MaxHp;

        }
        //m_scrollbarInjure.size = CurrPlayerHp / PlayerHp;
        SetHp(CurrHp / MaxHp);
       
    }

    public void SetMaxHp(float MaxHp,float CurrHp)
    {
        this.MaxHp = MaxHp;
        this.CurrHp = CurrHp;
        SetHp(CurrHp / MaxHp);
    }

    public void SetHp(float pre)
    {
        Vector3 temp = m_imgSubimg.rectTransform.anchoredPosition;
        temp.x = pre * (MaxX - MinX) + MinX;
        m_imgSubimg.rectTransform.anchoredPosition = temp;
    }

    public void dDestroy()
    {
        if (isDestory)
            return;
        Destroy(this.gameObject);
        isDestory = true;
    }
}
