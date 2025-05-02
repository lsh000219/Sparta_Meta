using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public void Init(GoblinUIManager uiManager)
    {
        base.Init(uiManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        GoblinManager.instance.StartGame();
    }

    public void OnClickExitButton()
    {
        GoblinUIManager.instance.SetWaiting();
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}