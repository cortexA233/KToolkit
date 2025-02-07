using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KToolkit
{
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
        
        public static void System_DebugLog(params object[] args)
        {
            if (!debuggerConfig["System"])
            {
                return;
            }
            string res = "<color=green>System Log:</color> " + DebuggerConcatArgs(args);
            Debug.Log(res);
        }
        
        public static void Error_DebugLog(params object[] args)
        {
            // if (!debuggerConfig["System"])
            // {
            //     return;
            // }
            string res = "<color=red>Error Log:</color> " + DebuggerConcatArgs(args);
            Debug.Log(res);
        }
        
        public static void Cortex_DebugLog(params object[] args)
        {
            if (!debuggerConfig["Cortex"])
            {
                return;
            }
            string res = "<color=green>cortex Log:</color> " + DebuggerConcatArgs(args);
            Debug.Log(res);
        }

        public static void Shin_DebugLog(params object[] args)
        {
            if (!debuggerConfig["Shin"])
            {
                return;
            }
            
            string res = "<color=grey>Shin Log:</color> " + DebuggerConcatArgs(args);
            Debug.Log(res);
        }

        public static void WXT_DebugLog(params object[] args)
        {
            if (!debuggerConfig["Shin"])
            {
                return;
            }

            string res = "<color=red>WXT Log:</color> " + DebuggerConcatArgs(args);
            Debug.Log(res);
        }
    }

}
