using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameMode;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pvePanel;
    [SerializeField] private GameObject _pvpPanel;
    
    [SerializeField] private GameManager gameManager;
    
    public static SceneUIManager Instance { get; private set; }
    
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
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
        SceneManager.sceneLoaded += OnLoadScene;
    }


    /// <summary>
    /// 初始化开始菜单，记录引用，绑定监听
    /// </summary>
    private void StartMenuInit()
    {
        
    }

    private void OnLoadScene(Scene arg0, LoadSceneMode arg1)
    {
        switch (arg0.name)
        {
            case "StartMenu":
            {
                Debug.Log("StartMenu Loaded");
                
                _mainMenu = GameObject.Find("MenuPanel");
                _pvePanel = GameObject.Find("ChooseChessPanel_PVE");
                _pvpPanel = GameObject.Find("ChooseChessPanel_PVP");
        
        
                Button PVPButton = GameObject.Find("PVP").GetComponent<Button>();
                Button PVP_Exit = GameObject.Find("PVP_Exit").GetComponent<Button>();
                Button PVP_Confirm = GameObject.Find("PVP_Confirm").GetComponent<Button>();
        
                Button PVEButton = GameObject.Find("PVE").GetComponent<Button>();
                Button PVE_Exit = GameObject.Find("PVE_Exit").GetComponent<Button>();
                Button PVE_Confirm = GameObject.Find("PVE_Confirm").GetComponent<Button>();
                
                //绑定监听
                PVPButton.onClick.AddListener(()=> ShowPanel(_pvpPanel) );
                PVP_Exit.onClick.AddListener(()=> HidePanel(_pvpPanel) );
                PVP_Confirm.onClick.AddListener(EnterMultiPlayer);
            
                PVEButton.onClick.AddListener(()=> ShowPanel(_pvePanel) );
                PVE_Exit.onClick.AddListener(()=> HidePanel(_pvePanel) );
                PVE_Confirm.onClick.AddListener(EnterSinglePlayer);
        
                //Debug.Log("StartMenu Loaded");
                //界面初始化
                _mainMenu.SetActive(true);
                _pvePanel.SetActive(false);
                _pvpPanel.SetActive(false);
                
                break;
            }
            
            case "MainGame":
            {
                if (arg1 == LoadSceneMode.Additive)
                {
                    Button backButton = GameObject.Find("BackButton").GetComponent<Button>();
                    Button pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
                    Button settingButton = GameObject.Find("SettingButton").GetComponent<Button>();
                    
                    backButton.onClick.AddListener(ReturnMenu);
                }
                break;
            }
        }
        
        
        
        
    }

    // Start is called before the first frame update
    
    public void Start()
    {
        _mainMenu.SetActive(true);
        _pvePanel.SetActive(false);
        _pvpPanel.SetActive(false);
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
        SceneManager.LoadScene("MainGame",LoadSceneMode.Additive);
        GameManager.gameMode = PVE;
        _mainMenu.SetActive(false);
    }
    public void EnterMultiPlayer()
    {
        SceneManager.LoadScene("MainGame",LoadSceneMode.Additive);
        GameManager.gameMode = PVP;
        _mainMenu.SetActive(false);
    }

    public void ReturnMenu()
    {
        GameManager.gameMode = Quit;
        
        //SceneManager.UnloadSceneAsync("MainGame");
        SceneManager.LoadScene("StartMenu");
        
        if (!_mainMenu.gameObject.activeInHierarchy)
        {
            _mainMenu.SetActive(true);
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
