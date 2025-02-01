using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KToolkit;


public class KFrameworkManager : Singleton<KFrameworkManager>
{
    private GameObject frameworkManagerObject;
    
    protected override void Awake()
    {
        base.Awake();
    }

    public virtual void InitKFramework()
    {
        
    }

    private void Update()
    {
        KUIManager.instance.Update();
        KTimerManager.instance.Update();
    }
}
