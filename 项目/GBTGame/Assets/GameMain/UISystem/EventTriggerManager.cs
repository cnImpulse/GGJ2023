using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventTriggerManager : EventTrigger//��̳���EventTrigger
{
    //��д�¼��ű�

    public delegate void ClickDownListener(GameObject game);//����¼�ί��
    public ClickDownListener onClickDown;//����¼�ί��ʵ��

    public delegate void ClickUpListener(GameObject game);//�����¼�ί��
    public ClickUpListener onClickUp;//�����¼�ί��ʵ��

    public delegate void PointEnter(GameObject game);//�����ͣί��
    public PointEnter onPointEnter;

    public delegate void Move(GameObject game);//�ƶ��¼�ί��
    public Move onMove;//�ƶ��¼�ί��ʵ��

    public static EventTriggerManager Get(GameObject game)//Get����
    {
        EventTriggerManager eventTriggerManager = game.GetComponent<EventTriggerManager>();//�õ�Ŀ�������ϵĴ˽ű�
        if (eventTriggerManager == null)//��Ϊ��
        {
            eventTriggerManager = game.AddComponent<EventTriggerManager>();//��̬����
        }
        return eventTriggerManager;//���ش˽ű�
    }
    public override void OnDrag(PointerEventData eventData)//��д�����е��ƶ�����,����ͬ��
    {
        if (onMove != null)//��ί�в�Ϊ�գ���ִ�д�ί��
        {
            onMove.Invoke(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onClickDown != null)
        {
            onClickDown.Invoke(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onClickUp != null)
        {
            onClickUp.Invoke(gameObject);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if(onPointEnter!=null)
        {
            onPointEnter.Invoke(gameObject);
        }
    }
}