using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public partial class UIManager : SingletonNoMono<UIManager>
{
    private List<UIBase> uiList = new List<UIBase>();
    private List<UIBase> pageStack = new List<UIBase>();
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
        var newPage = new T();
        newPage.gameObject = GameObject.Instantiate(Resources.Load<GameObject>(pageDict[typeof(T)].prefabPath),
            GameObject.Find("Canvas").transform);
        newPage.transform = newPage.gameObject.transform;
        newPage.InitParams(args);
        uiList.Add(newPage);
        newPage.onStart();
        KDebugLogger.UI_DebugLog("UI Create: ", pageDict[typeof(T)].name);
        return newPage;
    }

    public void DestroyUI(UIBase page)
    {
        uiList.Remove(page);
        Object.Destroy(page.gameObject);
        page.onDestroy();
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
