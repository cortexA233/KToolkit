using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;

public abstract class UIBase : ObserverNoMono
{
    public bool isPage { get; protected set; } = false;
    // 和MonoBehavior的gameObject属性类似，在OnStart时初始化
    public GameObject gameObject;
    // 和MonoBehavior的transform属性类似，在OnStart时初始化
    public Transform transform;
    
    public virtual void InitParams(params object[] args)
    {
        
    }
    
    public override void DestroySelf()
    {
        base.DestroySelf();
        UIManager.instance.DestroyUI(this);
    }
    
    public virtual void OnStart() {}
    public virtual void OnDestroy() {}
    public virtual void Update() {}
}


public abstract class UIPage : UIBase
{
    public override void OnStart()
    {
        base.OnStart();
        isPage = true;
    }
    
}
