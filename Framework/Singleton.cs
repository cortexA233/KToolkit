using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public class Singleton<T> : Observer where T: Singleton<T>, new()
{
    public static T instance;
    protected virtual void Awake()
    {
        instance = (T)this;
    }
}


public class SingletonNoMono<T> : ObserverNoMono where T : SingletonNoMono<T>, new()
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    public virtual void Init()
    {
        
    }
}
