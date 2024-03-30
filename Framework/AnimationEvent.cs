using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEvent : MonoBehaviour
{
    public delegate void AnimCallback();
    private Dictionary<string, AnimCallback> callbackMap = new Dictionary<string, AnimCallback>();

    public void OnAnimEvent(string eventName)
    {
        if (callbackMap.ContainsKey(eventName))
        {
            callbackMap[eventName]();
        }
    }

    public void SetAnimEventCallBack(string eventName, AnimCallback callback)
    {
        if (callbackMap.ContainsKey(eventName))
        {
            callbackMap[eventName] = callback;
            return;
        }
        callbackMap.Add(eventName, callback);
    }
}
