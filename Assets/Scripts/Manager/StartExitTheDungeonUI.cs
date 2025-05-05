using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartExitTheDungeonUI : BaseNPC
{
    [SerializeField] private Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("ExitTheDungeonScene");
    }
}
