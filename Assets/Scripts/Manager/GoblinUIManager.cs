using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    Waiting,
    Home,
    Game,
    GameOver,
}

public class GoblinUIManager : UIManager
{
    public static GoblinUIManager instance;
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    private UIState currentState;


    private void Awake()
    {
        instance = this;
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Waiting);
    }

    public void SetWaiting()
    {
        ChangeState(UIState.Waiting);
    }

    public void SetHome()
    {
        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        gameUI.UpdateWaveText(waveIndex);
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        gameUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}