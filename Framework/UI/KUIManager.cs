using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public partial class KUIManager : SingletonNoMono<KUIManager>
{
    private List<UIBase> uiList = new List<UIBase>();

    public List<UIBase> DebugGetUIList()
    {
        return uiList;
    }

    // private List<UIPage> pageStack = new List<UIPage>();
    private static int singletonNum = 0;
    public KUIManager()
    {
        // UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Canvas"));
        ++singletonNum;
        if (singletonNum > 1)
        {
            Debug.LogError("错误！KUIManager创建了第二个多余的实例，请检查代码！" + singletonNum);
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
        // if (newUI is UIPage)
        // {
        //     if (pageStack.Count > 0)
        //     {
        //         pageStack[^1].Deactivate();
        //     }
        //     pageStack.Add((UIPage)(object)newUI);
        //     pageStack[^1].Activate();
        // }
        KDebugLogger.UI_DebugLog("UI 创建: ", uiMap[typeof(T)].name);
        return newUI;
    }

    public void DestroyUI(UIBase ui)
    {
        uiList.Remove(ui);
        // if (ui is UIPage)
        // {
        //     pageStack.Remove((UIPage)ui);
        //     if (pageStack.Count > 0)
        //     {
        //         pageStack[^1].Activate();
        //     }
        // }
        KDebugLogger.UI_DebugLog("UI 销毁: ", ui);
        ui.OnDestroy();
        Object.Destroy(ui.gameObject);
        ui.DestroySelf();
    }

    public void HideUI(UIBase ui)
    {
        ui.gameObject.SetActive(false);
        // if (ui is UIPage)
        // {
        //     pageStack.Remove((UIPage)ui);
        //     if (pageStack.Count > 0)
        //     {
        //         pageStack[^1].Activate();
        //     }
        // }
        KDebugLogger.UI_DebugLog("UI 隐藏: ", ui);
    }

    public void HideAllUIWithType<T>() where T : UIBase
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i].GetType() == typeof(T))
            {
                HideUI(uiList[i]);
            }
        }
    }

    public void ShowUI(UIBase ui)
    {
        ui.gameObject.SetActive(true);
        // if (ui is UIPage)
        // {
        //     pageStack.Remove((UIPage)ui);
        //     if (pageStack.Count > 0)
        //     {
        //         pageStack[^1].Activate();
        //     }
        // }
        KDebugLogger.UI_DebugLog("UI 重新显示: ", ui);
    }

    public void ShowAllUIWithType<T>() where T : UIBase
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {
            if (uiList[i].GetType() == typeof(T))
            {
                ShowUI(uiList[i]);
            }
        }
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
            if (i > uiList.Count - 1)
            {
                continue;
            }
            if (uiList[i] is not null && uiList[i].GetType() == typeof(T))
            {
                DestroyUI(uiList[i]);
            }
        }
    }

    public Camera GetUICamera()
    {
        return GameObject.Find("UICamera").GetComponent<Camera>();
    }

    public Canvas GetCanvas()
    {
        return GameObject.Find("Canvas").GetComponent<Canvas>();
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
