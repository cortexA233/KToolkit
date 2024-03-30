using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KDebugLogger
{
    public static void UI_DebugLog(params object[] args)
    {
        string res = "UI Log: ";
        foreach (var item in args)
        {
            res += item;
            res += "  ";
        }
        Debug.Log(res);
    }
}
