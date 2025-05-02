using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GoblinUIManager : UIManager
{
    public static GoblinUIManager instance;
    GoblinStartUI homeUI;
    GoblinGameUI gameUI;
    GoblinGameOverUI gameOverUI;
    private UIState currentState;


    private void Awake()
    {
        instance = this;
        homeUI = GetComponentInChildren<GoblinStartUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GoblinGameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GoblinGameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Waiting);
    }

    public void SetWaiting()
    {
        ChangeState(UIState.Waiting);
    }

    public void SetHome()
    {
        ChangeState(UIState.GoblinStart);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.GoblinGame);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GoblinGameOver);
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