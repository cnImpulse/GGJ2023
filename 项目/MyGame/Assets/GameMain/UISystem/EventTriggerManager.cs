using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventTriggerManager : EventTrigger//需继承自EventTrigger
{
    //重写事件脚本

    public delegate void ClickDownListener(GameObject game);//点击事件委托
    public ClickDownListener onClickDown;//点击事件委托实例

    public delegate void ClickUpListener(GameObject game);//弹起事件委托
    public ClickUpListener onClickUp;//弹起事件委托实例

    public delegate void PointEnter(GameObject game);//鼠标悬停委托
    public PointEnter onPointEnter;

    public delegate void Move(GameObject game);//移动事件委托
    public Move onMove;//移动事件委托实例

    public static EventTriggerManager Get(GameObject game)//Get方法
    {
        EventTriggerManager eventTriggerManager = game.GetComponent<EventTriggerManager>();//得到目标物体上的此脚本
        if (eventTriggerManager == null)//若为空
        {
            eventTriggerManager = game.AddComponent<EventTriggerManager>();//动态挂载
        }
        return eventTriggerManager;//返回此脚本
    }
    public override void OnDrag(PointerEventData eventData)//重写父类中的移动方法,以下同理
    {
        if (onMove != null)//若委托不为空，则执行此委托
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