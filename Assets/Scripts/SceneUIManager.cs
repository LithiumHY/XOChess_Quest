using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static GameMode;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _pvePanel;
    [SerializeField] private GameObject _pvpPanel;
    [SerializeField] private GameObject _gameCanvas;
    
   private Button PVPButton;
   private Button PVP_Exit;
   private Button PVP_Confirm;
   
   private Button PVEButton;
   private Button PVE_Exit;
   private Button PVE_Confirm;
    
    [SerializeField] private GameManager gameManager;
    
    public static SceneUIManager Instance { get; private set; }
    
    private void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        UIInit();

        //界面初始化
        _menuCanvas.SetActive(true);
        _pvePanel.SetActive(false);
        _pvpPanel.SetActive(false);
        
        //SceneManager.sceneLoaded += OnLoadScene;
    }

    /// <summary>
    /// UI初始化，记录引用，绑定监听
    /// </summary>
    private void UIInit()
    {
        _menuCanvas = GameObject.Find("MenuCanvas");
        _gameCanvas = GameObject.Find("GameCanvas");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _pvePanel = GameObject.Find("ChooseChessPanel_PVE");
        _pvpPanel = GameObject.Find("ChooseChessPanel_PVP");
        
        
        PVPButton = GameObject.Find("PVP").GetComponent<Button>();
        PVP_Exit = GameObject.Find("PVP_Exit").GetComponent<Button>();
        PVP_Confirm = GameObject.Find("PVP_Confirm").GetComponent<Button>();
        _pvpPanel.GetComponent<PVPPanel>().Init();
        
        PVEButton = GameObject.Find("PVE").GetComponent<Button>();
        PVE_Exit = GameObject.Find("PVE_Exit").GetComponent<Button>();
        PVE_Confirm = GameObject.Find("PVE_Confirm").GetComponent<Button>();
        _pvePanel.GetComponent<PVEPanel>().Init();
        
        
        Button backButton = GameObject.Find("BackButton").GetComponent<Button>();
        Button pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        Button settingButton = GameObject.Find("SettingButton").GetComponent<Button>();
        
        //绑定监听
        PVPButton.onClick.AddListener(()=> ShowPanel(_pvpPanel) );
        PVP_Exit.onClick.AddListener(()=> HidePanel(_pvpPanel) );
        PVP_Confirm.onClick.AddListener(OnPVPConfirmClicked);

        PVEButton.onClick.AddListener(() => ShowPanel(_pvePanel));
        PVE_Exit.onClick.AddListener(()=> HidePanel(_pvePanel) );
        PVE_Confirm.onClick.AddListener(OnPVEConfirmClicked);
        
        backButton.onClick.AddListener(ReturnMenu);
    }

   


    /// <summary>
    /// 初始化开始菜单，记录引用，绑定监听
    /// </summary>
    
    
    public void Start()
    {
        _menuCanvas.SetActive(true);
        _pvePanel.SetActive(false);
        _pvpPanel.SetActive(false);
        _gameCanvas.SetActive(false);
    }
    
    public void ShowPanel(GameObject panel)
    {
        if (!panel.activeInHierarchy)
        {
            panel.SetActive(true);
        }
        
        //TODO playAnim
    }
    
    public void HidePanel(GameObject panel)
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        
        //TODO playAnim
    }
    
    //TODO 保存玩家的选择信息并传入GameManager
    private void OnPVEConfirmClicked()
    {
        GameManager.gameMode = PVE;
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
        
        int chessType = _pvePanel.GetComponent<PVEPanel>().GetChessType();
        int AIType = _pvePanel.GetComponent<PVEPanel>().GetAIType();
        bool isPlayerOffensive = _pvePanel.GetComponent<PVEPanel>().GetPlayerOffensive();
        
        SetSinglePlayer(chessType, AIType, isPlayerOffensive);
        
        void SetSinglePlayer(int ChessType, int AIType, bool isPlayerOffensive)
        {
            AIType++;
            gameManager.curPlayersStats = new List<ChessPlayerStru>()
            {
                PlayerStatsUtlis.SetPlayerStatus(0, isPlayerOffensive, ChessType),
                PlayerStatsUtlis.SetPlayerStatus( (ChessPlayerStatus)AIType, !isPlayerOffensive, ChessType == 0 ? 1 : 0)
            };
       
        }
    }
    
    
    //TODO 保存玩家的选择信息并传入GameManager
    public void OnPVPConfirmClicked()
    {
        GameManager.gameMode = PVP;
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
        
        int P1Chess = _pvpPanel.GetComponent<PVPPanel>().GetP1Type();
        int P2Chess = _pvpPanel.GetComponent<PVPPanel>().GetP2Type();
        SetMultiPlayer(P1Chess, P2Chess);

        void SetMultiPlayer(int p1Chess, int p2Chess)
        {
            gameManager.curPlayersStats = new List<ChessPlayerStru>()
            {
                PlayerStatsUtlis.SetPlayerStatus(0, true, p1Chess),
                PlayerStatsUtlis.SetPlayerStatus(0, false, p2Chess)
            };
        }
    }

    public void ReturnMenu()
    {
        //重置数据和模式
        GameManager.gameMode = Quit;
        gameManager.curPlayersStats.Clear();
        _gameCanvas.SetActive(false);
        
        
        if (!_menuCanvas.gameObject.activeInHierarchy)
        {
            _menuCanvas.SetActive(true);
        }
        
        if(_pvpPanel.gameObject.activeInHierarchy)
        {
            _pvpPanel.SetActive(false);
        }
        
        if(_pvePanel.gameObject.activeInHierarchy)
        {
            _pvePanel.SetActive(false);
        }
    }

    public void GlobalSetting()
    {
        //Debug.Log("Quit Game!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
        
}
