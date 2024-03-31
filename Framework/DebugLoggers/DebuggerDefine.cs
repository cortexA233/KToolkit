using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class KDebugLogger
{
    public static void UI_DebugLog(params object[] args)
    {
        if (!debuggerConfig["UI"])
        {
            return;
        }
        string res = "<color=yellow>UI Log:</color> " + DebuggerConcatArgs(args);
        Debug.Log(res);
    }
    
    public static void Level_DebugLog(params object[] args)
    {
        if (!debuggerConfig["Level"])
        {
            return;
        }
        string res = "<color=blue>Level Log:</color> " + DebuggerConcatArgs(args);
        Debug.Log(res);
    }
    
    public static void Player_DebugLog(params object[] args)
    {
        if (!debuggerConfig["Player"])
        {
            return;
        }
        string res = "<color=red>Player Log:</color> " + DebuggerConcatArgs(args);
        Debug.Log(res);
    }
}
