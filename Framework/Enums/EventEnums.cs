

public enum EventName
{
    PlayerCountDownDie,             // 玩家死亡（超过10s时限），暂时无参数
    PlayerRespawn,                  // 玩家复活，参数1:Vector3（重生位置）
    KillPlayer,                     // 杀死玩家通知，参数1:bool（是否为结局剧情杀）
    SpikeTouchPlayer,               // 刺接触玩家通知
    KillPlayerConfirm,              // 杀死玩家通知确认（避免非必要地多次重复kill玩家），暂时无参数
    
    ClearAllShadowNotify,           // 清除所有影子通知，暂时无参数
    
    EnterMagnetArea,                // 进入磁性区域，参数1:GameObject（进入的物体），参数2:GameObject（磁铁物体），参数3:Vector2（吸附方向）
    ExitMagnetArea,                 // 离开磁性区域，参数1:GameObject（离开的物体），参数2:GameObject（磁铁物体）
    
    BoxRespawn,                     // 箱子重生，暂时无参数
    OneTimePlatformRespawn,         // 单次平台重生/重置，暂时无参数
    MovingPlatformRespawn,          // 移动平台重生/重置，暂时无参数
    OneTimeMovingPlatformRespawn,   // 一次性移动平台重生/重置，暂时无参数
    DoorRespawn,                    // 门重置，暂时无参数

    ButtonRespawn,                  // 按钮重置测试，暂时无参数
    
    ClearPlayerShadowRecord,        // 清除玩家影子记录，暂时无参数
    ClearBoxShadowRecord,           // 清除箱子影子记录，暂时无参数
    BackupShadowRecord,             // 如果为倒计时结束死亡，则影子记录需要备份通知，暂时无参数
    
    ButtonOn,                       // 按钮被按下，参数1：int（按钮的id）
    ButtonOff,                      // 按钮弹起，参数1：int（按钮的id）

    EnterLevel,                     // 进入关卡，参数1:切换到的关卡场景名
    ClearLevel,                     // 通过关卡，参数1:GameObject(场景终点门的game object)，参数2:levelConfig(当前关卡config)
    
    ResumeCountDown,                // 通知计时器开始计时的事件，暂时无参数
    PauseCountDown,                 // 通知计时器暂停计时的事件，暂时无参数
    PauseCountDownClearLevel,       // 通知计时器暂停计时的事件（过关专用），暂时无参数
    
    RevealStartMenu,                // 关闭选关时显示start menu，暂时无参数
    ReturnToStartMenu,              // 关闭选关时显示start menu，参数1:返回页面类型(BackToMenuType)
    
    IgnitePlayer,                   // 点燃玩家（开始计时），参数1:GameObject(玩家火的game object)，参数2:bool(是否播放音效)
    IgniteShadow,                   // 点燃影子，参数1:GameObject(影子的game object)
    DousePlayer,                    // 玩家熄火（暂停计时）
    DouseShadow,                    // 影子熄火，参数1:GameObject(影子的game object)
    
    StartHint,                      // 玩家启动卡关提示通知，暂时无参数
    
    //成就相关
    ForceField10Times,
    FinishLevelInLastSecond,
    Shadow_Chapter1,
    Box_Chapter2,
    Force_Chapter3,
    Laser_Chapter4,
    Fire_Chapter5,
    
}


//事件类型暂时不做，统一不做区分
// public enum EventType
// {
//     UI,
//     Game,
// }