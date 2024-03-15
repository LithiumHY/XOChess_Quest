using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPlace : MonoBehaviour
{
    private GameManager _gameManager;
    
    [Header("棋子样式 ")] 
    [SerializeField] private Sprite spriteBlank;
    [SerializeField] private Sprite spriteX ;
    [SerializeField] private Sprite spriteO ;
    
    private void Awake()
    {
        //绑定监听
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(OnChessClicked);
        
        //设置样式
        gameObject.GetComponent<Image>().sprite = spriteBlank;
    }
    
    private void OnChessClicked()
    {
        _gameManager.ChessClicked(gameObject);
    }
}
