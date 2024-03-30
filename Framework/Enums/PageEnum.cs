using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 使用这个特性可以自动加进UIManager的pageDict当中
/// </summary>
public class UIPageAttribute : Attribute
{
    public string prefabPath;
    public string name;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="path">预制体相对于Resources/UIPrefabs的目录</param>
    /// <param name="uiName">UI的名字，一般是类名</param>
    public UIPageAttribute(string path, string uiName)
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

public partial class UIManager
{
    private static Dictionary<Type, UIPageAttribute> pageDict = new Dictionary<Type, UIPageAttribute>();
    // 新建页面在此处注册
    private void InitPageDict()
    {
        pageDict[typeof(GameMainPage)] = new UIPageAttribute("empty", "GameMainPage");
        pageDict[typeof(CountDownPage)] = new UIPageAttribute("count_down_UI", "CountDownPage");
        pageDict[typeof(LevelSelectPage)] = new UIPageAttribute("level_select/level_select_ui", "LevelSelectPage");
        pageDict[typeof(StartMenuPage)] = new UIPageAttribute("StartMenuUI", "StartMenuPage");
        pageDict[typeof(ChallengeSelectPage)] = new UIPageAttribute("level_select/challenge_select_ui", "ChallengeSelectPage");
        pageDict[typeof(GMPage)] = new UIPageAttribute("GM/gm_page", "GMPage");
        pageDict[typeof(GeneralFadePage)] = new UIPageAttribute("general_fade_ui", "GeneralFadePage");
        pageDict[typeof(TutorialBubbleUI)] = new UIPageAttribute("tutorial_bubble_ui", "TutorialBubbleUI");
    }
    
    // 两种方式添加到字典中
    private void AutoInitPageDict()
    {
        var UIPagesType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(UIBasePage)))
            .Where(type => type.GetCustomAttribute<UIPageAttribute>() != null);
        foreach (var type in UIPagesType)
        {
            if (!pageDict.ContainsKey(type)) // 简单判重
                pageDict.Add(type,
                    new UIPageAttribute(type.GetCustomAttribute<UIPageAttribute>().prefabPath,
                        type.GetCustomAttribute<UIPageAttribute>().name));
        }
    }
}
