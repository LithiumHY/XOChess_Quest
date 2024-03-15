using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _backButton;
    private Button _pauseButton;
    private Button _settingButton;

    private SceneUIManager _sceneUIManager;
    private GameManager _gameManager;
    

    private void Awake()
    {
        _backButton = GameObject.Find("BackButton").GetComponent<Button>();
        _pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        _settingButton = GameObject.Find("SettingButton").GetComponent<Button>();
        
       _sceneUIManager = GameObject.Find("SceneUIManager").GetComponent<SceneUIManager>();

       _backButton.onClick.AddListener(_sceneUIManager.ReturnMenu);
    }
}
