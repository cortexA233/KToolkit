using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Observer : MonoBehaviour
{
    private Dictionary<EventName, UnityAction<object[]>> _eventMap = new Dictionary<EventName, UnityAction<object[]>>();
    
    protected void AddEventListener(EventName eventName, UnityAction<object[]> func)
    {
        EventManager.AddListener(this, eventName);
        _eventMap[eventName] = func;
    }

    public void __CallEventMap(EventName eventName, params object[] args)
    {
        _eventMap[eventName](args);
    }
}


public abstract class ObserverNoMono
{
    private Dictionary<EventName, UnityAction<object[]>> _eventMap = new Dictionary<EventName, UnityAction<object[]>>();
    public bool isDestroyed { get; protected set; }
    protected void AddEventListener(EventName eventName, UnityAction<object[]> func)
    {
        EventManager.AddListener(this, eventName);
        _eventMap[eventName] = func;
    }

    public void __CallEventMap(EventName eventName, params object[] args)
    {
        _eventMap[eventName](args);
    }

    public virtual void DestroySelf()
    {
        isDestroyed = true;
        EventManager.DeleteObserver(this);
    }
}
