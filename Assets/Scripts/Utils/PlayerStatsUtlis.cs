
using System;
using UnityEngine;



public static class PlayerStatsUtlis
{
    /// <summary>
    /// 传递UI设置的信息给棋盘
    /// </summary>
    /// <param name="playerStatus"></param>
    /// <param name="isOffensive"></param>
    /// <param name="ChessType"></param>
    /// <returns></returns>
    public static ChessPlayerStru SetPlayerStatus(ChessPlayerStatus playerStatus, bool isOffensive, int ChessType)
    {
        Sprite _spriteX = Resources.Load<Sprite>("Sprites/mark_X");
        Sprite _spriteO = Resources.Load<Sprite>("Sprites/mark_O");
        
        return new ChessPlayerStru()
        {
            playerStatus = playerStatus,
            isOffensive = isOffensive,
            chessSprite = ChessType == 0 ? _spriteO : _spriteX
        };
    }
}


public enum GameMode
{
    PVP,
    PVE,
    Quit
}

/// <summary>
/// 存储下棋棋手的信息
/// </summary>
[Serializable]
public struct ChessPlayerStru
{
    //局外传入局内 不会更改
    public ChessPlayerStatus playerStatus;
    public bool isOffensive;
    public Sprite chessSprite;
    
}

/// <summary>
/// 当前棋手所处的状态
/// </summary>
public enum ChessPlayerStatus
{
    Player = 0,
    EasyAI = 1,
    MediumAI = 2,
}