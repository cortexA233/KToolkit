using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public partial class UIManager : SingletonNoMono<UIManager>
{
    private List<UIBase> uiList = new List<UIBase>();
    private List<UIPage> pageStack = new List<UIPage>();
    private static int singletonNum = 0;
    public UIManager()
    {
        // UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Canvas"));
        ++singletonNum;
        if (singletonNum > 1)
        {
            Debug.LogError("错误！UIManager创建了第二个多余的实例，请检查代码！" + singletonNum);
        }
        InitPageDict();
        AutoInitPageDict();
    }
    
    public T CreateUI<T>(params object[] args) where T : UIBase, new()
    {
        var newUI = new T();
        newUI.gameObject = GameObject.Instantiate(Resources.Load<GameObject>(uiMap[typeof(T)].prefabPath),
            GameObject.Find("Canvas").transform);
        newUI.transform = newUI.gameObject.transform;
        newUI.InitParams(args);
        uiList.Add(newUI);
        newUI.OnStart();
        if (newUI is UIPage)
        {
            if (pageStack.Count > 0)
            {
                pageStack[^1].Deactivate();
            }
            pageStack.Add((UIPage)(object)newUI);
            pageStack[^1].Activate();
        }
        KDebugLogger.UI_DebugLog("UI Create: ", uiMap[typeof(T)].name);
        return newUI;
    }

    public void DestroyUI(UIBase ui)
    {
        uiList.Remove(ui);
        if (ui is UIPage)
        {
            pageStack.Remove((UIPage)ui);
            if (pageStack.Count > 0)
            {
                pageStack[^1].Activate();
            }
        }
        KDebugLogger.UI_DebugLog(ui);
        Object.Destroy(ui.gameObject);
        ui.OnDestroy();
    }

    public void DestroyFirstUIWithType<T>() where T : UIBase
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i].GetType() == typeof(T))
            {
                DestroyUI(uiList[i]);
                break;
            }
        }
    }
    
    public UIBase GetFirstUIWithType<T>() where T : UIBase
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i].GetType() == typeof(T))
            {
                return uiList[i];
            }
        }
        return null;
    }

    public void DestroyAllUI()
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            DestroyUI(uiList[i]);
        }
    }

    public void DestroyAllUIWithType<T>() where T : UIBase
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i].GetType() == typeof(T))
            {
                DestroyUI(uiList[i]);
            }
        }
    }

    public Camera GetUICamera()
    {
        return GameObject.Find("UICamera").GetComponent<Camera>();
    }

    public void Update()
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i] != null && !uiList[i].isDestroyed)
            {
                uiList[i].Update();
            }
        }
    }
}
