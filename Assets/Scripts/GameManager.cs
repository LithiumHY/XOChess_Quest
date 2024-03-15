using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    
    
    [ShowInInspector] public static GameMode gameMode = GameMode.Quit;


    /// <summary>
    /// 点击下棋时触发的函数
    /// </summary>
    /// <param name="currentChess">下棋选中的棋子坐标</param>
    public void ChessClicked(GameObject currentChess)
    {
        Debug.Log(currentChess.name);
    }
}

public enum GameMode
{
    PVP,
    PVE,
    Quit
}
