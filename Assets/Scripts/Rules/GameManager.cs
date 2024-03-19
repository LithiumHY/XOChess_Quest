using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class GameManager : MonoBehaviour
{
    //TODO：下棋逻辑（在UI上改变）
    //TODO：让AI能够在上面下棋，返回的函数也调用下棋函数
    //TODO：判断输赢


    //TODO：兼容NodeCanvas
    //TODO：动效和可视化
    //TODO：用Linerenderer显示赢家连成的线
    //TODO：用不同的颜色（描边Shader）显示不同示例

    //TODO：悔棋
    
    //singleton
    public static GameManager Instance { get; private set; }
    
    
    /// <summary>
    /// 棋子列表
    /// </summary>
    [ShowInInspector] private List<GameObject> _chessList;

    [ShowInInspector] private List<GameObject> _emptyChessList;
    [ShowInInspector] public static GameMode gameMode = GameMode.Quit;
    /// <summary>
    /// 空白棋子Sprite
    /// </summary>
    [SerializeField] private Sprite _spriteBlank;
    [SerializeField] private Sprite _spriteX;
    [SerializeField] private Sprite _spriteO;

    [SerializeField] public List<ChessPlayerStru> curPlayersStats;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        // _spriteBlank = Resources.Load<Sprite>("Sprites/Blank");
        // _spriteX = Resources.Load<Sprite>("Sprites/mark_X");
        // _spriteO = Resources.Load<Sprite>("Sprites/mark_O");
        
        curPlayersStats = new List<ChessPlayerStru>(2);
        
        SceneManager.sceneLoaded += OnMainGameLoaded;
        
    }

    /// <summary>
    /// 场景加载时触发的监听事件
    /// </summary>
    /// <param name="arg0"></param>
    /// <param name="arg1"></param>
    private void OnMainGameLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //初始化棋子列表
        _chessList = new List<GameObject>();
        _emptyChessList = new List<GameObject>();
        
        
        //更新场景逻辑
        if (arg1 == LoadSceneMode.Additive && arg0.name == "MainGame") 
        {
            //Debug.Log("MainGame Loaded");
            //初始化棋盘
            if(_chessList.Count != 0)
            {
                _chessList.Clear();
            }
            else
            {
                GameObject chessBoard = GameObject.Find("ChessBoard");
                
                for (int i = 0; i < chessBoard.transform.childCount; i++)
                {
                    _chessList.Add(chessBoard.transform.GetChild(i).gameObject);
                }
            }
        }
    }
    
    /// <summary>
    /// 点击下棋时触发的函数
    /// </summary>
    /// <param name="currentChess">下棋选中的棋子对应的GameObject</param>
    public void ChessClicked(GameObject currentChess)
    {
        Debug.Log(currentChess.name);
        _emptyChessList = GetEmptyChess();
    }
    
    /// <summary>
    /// 获得当前没有子的
    /// </summary>
    /// <returns></returns>
    private List<GameObject> GetEmptyChess()
    {
        List<GameObject> emptyChess = new List<GameObject>();
        foreach (var chess in _chessList)
        {
            if (chess.GetComponent<Image>().sprite == _spriteBlank)
            {
                emptyChess.Add(chess);
            }
        }

        return emptyChess;
    }

    
    
    
}




