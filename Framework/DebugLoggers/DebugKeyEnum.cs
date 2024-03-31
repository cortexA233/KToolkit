using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class KDebugLogger
{
    private static Dictionary<string, bool> debuggerConfig = new Dictionary<string, bool>();

    static KDebugLogger()
    {
        debuggerConfig["UI"] = true;
        debuggerConfig["Battle"] = true;
        debuggerConfig["System"] = true;
        debuggerConfig["Player"] = true;
        debuggerConfig["Level"] = true;
    }

    public static string DebuggerConcatArgs(params object[] args)
    {
        string res = "";
        foreach (var item in args)
        {
            res += item.ToString();
            res += "  ";
        }
        return res;
    }
}
