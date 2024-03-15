using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameMode;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    
    [SerializeField] private GameManager gameManager;
    
    private void Awake()
    {
        _mainMenu = GameObject.Find("MenuPanel");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    public void SinglePlayer()
        {
            SceneManager.LoadSceneAsync("MainGame",LoadSceneMode.Additive);
            GameManager.gameMode = PVE;
            _mainMenu.SetActive(false);
        }
        public void MultiPlayer()
        {
            SceneManager.LoadSceneAsync("MainGame",LoadSceneMode.Additive);
            GameManager.gameMode = PVP;
            _mainMenu.SetActive(false);
        }
    
        public void ReturnMenu()
        {
            GameManager.gameMode = Quit;
            SceneManager.UnloadSceneAsync("MainGame");
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
