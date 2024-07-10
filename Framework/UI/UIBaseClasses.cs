using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public abstract class UIBase : ObserverNoMono
{
    // 和MonoBehavior的gameObject属性类似，在OnStart时初始化
    public GameObject gameObject;
    // 和MonoBehavior的transform属性类似，在OnStart时初始化
    public Transform transform;

    protected List<UICell> childCellPool = new List<UICell>();
    
    public virtual void InitParams(params object[] args) {}

    public virtual void SetVisible(bool state)
    {
        gameObject.SetActive(state);
    }

    protected void CreateUICell<T>(Transform parent=null, params object[] args) where T : UICell, new()
    {
        T newCell = UIManager.instance.CreateUI<T>(args);
        if (parent)
        {
            newCell.transform.SetParent(parent);
        }
        else
        {
            newCell.transform.SetParent(this.transform);
        }
        childCellPool.Add(newCell);
    }

    public override void DestroySelf()
    {
        if (isDestroyed)
        {
            return;
        }

        for (int i = 0; i < childCellPool.Count; ++i)
        {
            childCellPool[i].DestroySelf();
        }
        base.DestroySelf();
        UIManager.instance.DestroyUI(this);
    }
    
    public virtual void OnStart() {}
    public virtual void OnDestroy() {}
    public virtual void Update() {}
}


// public abstract class UICell : UIBase
public abstract class UICell : UIBase
{
    
}


public abstract class UIPage : UIBase
{

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
