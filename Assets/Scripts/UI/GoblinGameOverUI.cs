using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoblinGameOverUI : BaseUI
{
    private ObjectManager objectManager;
    private GoblinManager goblinManager; 
    private PlayerController playerController;


    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        GoblinUIManager.instance.SetWaiting();
        GoblinManager.instance.Visible();
        PlayerController.instance.ExitGoblin();

    }

    protected override UIManager.UIState GetUIState()
    {
        return UIManager.UIState.GoblinGameOver;
    }
}