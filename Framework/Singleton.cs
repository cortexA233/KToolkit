using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public class Singleton<T> : Observer where T: Singleton<T>, new()
{
    private static T _instance;

    // public static T instance;
    public static T instance
    {
        get
        {
            // ȷ��ֻ����һ��ʵ��
            if (_instance == null)
            {
                // �������е� GameManager ʵ��
                _instance = FindObjectOfType<T>();

                // ���û���ҵ����򴴽�һ���µ�
                if (_instance == null)
                {
                    string objectName = typeof(T).Name;
                    GameObject instanceObject = new GameObject(objectName);
                    _instance = instanceObject.AddComponent<T>();
                    DontDestroyOnLoad(instanceObject); // ȷ���糡����������
                }
            }

            return _instance;
        }
    }
        
    protected virtual void Awake()
    {
        _instance = (T)this;
    }
}


public class SingletonNoMono<T> : ObserverNoMono where T : SingletonNoMono<T>, new()
{
    private static T _instance;
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
