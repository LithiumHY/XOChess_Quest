using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PVEPanel : MonoBehaviour
{
    [BoxGroup("PVESettings")] 
    [SerializeField] private TMP_Dropdown chessDropdown;
    
    [BoxGroup("PVESettings")] 
    [SerializeField] private TMP_Dropdown AIDropdown;
    
    [BoxGroup("PVESettings")]
    [SerializeField] private Toggle isPlayerOffensive;

    public void Init()
    {
        chessDropdown = GameObject.Find("ChessDropdown").GetComponent<TMP_Dropdown>();
        AIDropdown = GameObject.Find("AIDropdown").GetComponent<TMP_Dropdown>();
        isPlayerOffensive = GameObject.Find("IsPlayerOffensive").GetComponent<Toggle>();
    }
    
    /// <summary>
    /// 获得棋子的值
    /// </summary>
    /// <returns>0是O，1是X</returns>
    public int GetChessType()
    {
        return chessDropdown.value;
    }
    
    /// <summary>
    /// 获得AI难度
    /// </summary>
    /// <returns>0是简单（随机），1是Minimax AI（中等）</returns>
    public int GetAIType()
    {
        return AIDropdown.value;
    }
    
    /// <summary>
    /// 获得先后手
    /// </summary>
    /// <returns>true是先手，false是后手</returns>
    public bool GetPlayerOffensive()
    {
        return isPlayerOffensive.isOn;
    }
}
