using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using KToolkit;


public static class EventManager
{
    private static Dictionary<EventName, List<Observer>> observers = new Dictionary<EventName, List<Observer>>();
    private static Dictionary<EventName, List<ObserverNoMono>> observersNoMono = new Dictionary<EventName, List<ObserverNoMono>>();

    public static int DebugGetObserverCount()
    {
        return observers.Count + observersNoMono.Count;
    }
    
    public static void DeleteObserver(ObserverNoMono observer)
    {
        foreach (var item in observersNoMono)
        {
            item.Value.Remove(observer);
        }
    }

    public static void AddListener(Observer observer, EventName eventName)
    {
        if (!observers.ContainsKey(eventName))
        {
            observers[eventName] = new List<Observer>();
        }
        if (!observers[eventName].Contains(observer))
        {
            observers[eventName].Add(observer);
        }
    }
    public static void AddListener(ObserverNoMono observer, EventName eventName)
    {
        if (!observersNoMono.ContainsKey(eventName))
        {
            observersNoMono[eventName] = new List<ObserverNoMono>();
        }
        if (!observersNoMono[eventName].Contains(observer))
        {
            observersNoMono[eventName].Add(observer);
        }
    }
    
    public static void SendNotification(EventName eventName, params object[] args)
    {
        if (!observers.ContainsKey(eventName))
        {
            observers[eventName] = new List<Observer>();
        }
        if (!observersNoMono.ContainsKey(eventName))
        {
            observersNoMono[eventName] = new List<ObserverNoMono>();
        }

        for (int i = observers[eventName].Count - 1; i >= 0; --i)
        {
            if (observers[eventName][i] is null || observers[eventName][i].IsDestroyed())
            {
                observers[eventName].Remove(observers[eventName][i]);
                continue;
            }
            observers[eventName][i].__CallEventMap(eventName, args);
        }

        for (int i = observersNoMono[eventName].Count - 1; i >= 0; --i)
        {
            if (observersNoMono[eventName][i] == null || observersNoMono[eventName][i].isDestroyed)
            {
                observersNoMono[eventName].Remove(observersNoMono[eventName][i]);
                continue;
            }
            observersNoMono[eventName][i].__CallEventMap(eventName, args);
        }
    }
}
