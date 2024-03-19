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
        
        
        //初始化引用
        _menuCanvas = GameObject.Find("MenuCanvas");
        _gameCanvas = GameObject.Find("GameCanvas");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _pvePanel = GameObject.Find("ChooseChessPanel_PVE");
        _pvpPanel = GameObject.Find("ChooseChessPanel_PVP");
        
        PVPButton = GameObject.Find("PVP").GetComponent<Button>();
        PVP_Exit = GameObject.Find("PVP_Exit").GetComponent<Button>();
        PVP_Confirm = GameObject.Find("PVP_Confirm").GetComponent<Button>();
        
        PVEButton = GameObject.Find("PVE").GetComponent<Button>();
        PVE_Exit = GameObject.Find("PVE_Exit").GetComponent<Button>();
        PVE_Confirm = GameObject.Find("PVE_Confirm").GetComponent<Button>();
        
        Button backButton = GameObject.Find("BackButton").GetComponent<Button>();
        Button pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        Button settingButton = GameObject.Find("SettingButton").GetComponent<Button>();
        
        //绑定监听
        PVPButton.onClick.AddListener(()=> ShowPanel(_pvpPanel) );
        PVP_Exit.onClick.AddListener(()=> HidePanel(_pvpPanel) );
        PVP_Confirm.onClick.AddListener(EnterMultiPlayer);

        PVEButton.onClick.AddListener(() => ShowPanel(_pvePanel));
        PVE_Exit.onClick.AddListener(()=> HidePanel(_pvePanel) );
        PVE_Confirm.onClick.AddListener(EnterSinglePlayer);
        
        backButton.onClick.AddListener(ReturnMenu);
        
        //界面初始化
        _menuCanvas.SetActive(true);
        _pvePanel.SetActive(false);
        _pvpPanel.SetActive(false);
        
        //SceneManager.sceneLoaded += OnLoadScene;
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
    
    public void EnterSinglePlayer()
    {
        GameManager.gameMode = PVE;
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }
    public void EnterMultiPlayer()
    {
        GameManager.gameMode = PVP;
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    public void ReturnMenu()
    {
        GameManager.gameMode = Quit;
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
