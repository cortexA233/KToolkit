using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class UIBasePage : ObserverNoMono
{
    // 和MonoBehavior的gameObject属性类似，在onStart时初始化
    public GameObject gameObject;
    // 和MonoBehavior的transform属性类似，在onStart时初始化
    public Transform transform;
    
    public virtual void InitParams(params object[] args)
    {
        
    }
    
    public override void DestroySelf()
    {
        base.DestroySelf();
        UIManager.instance.DestroyUI(this);
    }
    
    public virtual void onStart() {}
    public virtual void onDestroy() {}
    public virtual void Update() {}
}


public class UISinglePage : UIBasePage
{
    public override void onStart()
    {
        base.onStart();
        EventManager.SendNotification(EventName.BoxRespawn);
    }
}
