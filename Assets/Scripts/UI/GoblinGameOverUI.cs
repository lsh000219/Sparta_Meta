using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoblinGameOverUI : BaseUI
{
    private ObjectManager objectManager;
    private GameManager gameManager; 
    private PlayerController playerController;


    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    private void Update() { ScoreText(); }
    private void ScoreText() { scoreText.text = (GameManager.instance.CurrentWaveIndex()).ToString(); }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        GoblinUIManager.instance.SetWaiting();
        GameManager.instance.Visible();
        PlayerController.instance.ExitGoblin();

    }

    protected override UIManager.UIState GetUIState()
    {
        return UIManager.UIState.GoblinGameOver;
    }
}