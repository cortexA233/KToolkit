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
    
    public virtual void InitParams(params object[] args)
    {
        
    }
    
    public override void DestroySelf()
    {
        if (isDestroyed)
        {
            return;
        }
        base.DestroySelf();
        UIManager.instance.DestroyUI(this);
    }
    
    public virtual void OnStart() {}
    public virtual void OnDestroy() {}
    public virtual void Update() {}
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
