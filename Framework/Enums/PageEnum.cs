using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


namespace KToolkit
{
        
    /// <summary>
    /// 使用这个特性可以自动加进KUIManager的pageDict当中
    /// </summary>
    public class UI_Info : Attribute
    {
        public string prefabPath;
        public string name;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path">预制体相对于Resources/UIPrefabs的目录</param>
        /// <param name="uiName">UI的名字，一般是类名</param>
        public UI_Info(string path, string uiName)
        {
            if (!path.StartsWith("UI_prefabs/"))
            {
                prefabPath = "UI_prefabs/" + path;
            }
            else
            {
                prefabPath = path;
            }
            name = uiName;
        }
    }

    public partial class KUIManager
    {
        private static Dictionary<Type, UI_Info> uiMap = new Dictionary<Type, UI_Info>();
        
        // 新建页面在此处注册
        private partial void InitPageDict();
        
        // 两种方式添加到字典中
        private void AutoInitPageDict()
        {
            var UIPagesType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(UIBase)))
                .Where(type => type.GetCustomAttribute<UI_Info>() != null);
            foreach (var type in UIPagesType)
            {
                if (!uiMap.ContainsKey(type)) // 简单判重
                    uiMap.Add(type,
                        new UI_Info(type.GetCustomAttribute<UI_Info>().prefabPath,
                            type.GetCustomAttribute<UI_Info>().name));
            }
        }
    }

}