using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace KToolkit
{
    public abstract class KObserver : MonoBehaviour
    {
        private Dictionary<EventName, UnityAction<object[]>> _eventMap = new Dictionary<EventName, UnityAction<object[]>>();
    
        protected void AddEventListener(EventName eventName, UnityAction<object[]> func)
        {
            KEventManager.AddListener(this, eventName);
            _eventMap[eventName] = func;
        }

        public void __CallEventMap(EventName eventName, params object[] args)
        {
            _eventMap[eventName](args);
        }
    }


    public abstract class KObserverNoMono
    {
        private Dictionary<EventName, UnityAction<object[]>> _eventMap = new Dictionary<EventName, UnityAction<object[]>>();
        public bool isDestroyed { get; protected set; }
        protected void AddEventListener(EventName eventName, UnityAction<object[]> func)
        {
            KEventManager.AddListener(this, eventName);
            _eventMap[eventName] = func;
        }

        public void __CallEventMap(EventName eventName, params object[] args)
        {
            _eventMap[eventName](args);
        }

        public virtual void DestroySelf()
        {
            isDestroyed = true;
            KEventManager.DeleteKObserver(this);
        }
    }
}

