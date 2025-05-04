using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartExitTheDungeonUI : UIManager
{
    private Canvas StartCanvas;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        StartCanvas = transform.Find("StartUI").GetComponent<Canvas>();
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCanvas.gameObject.SetActive(true);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("ExitTheDungeonScene");
    }

    public void OnClickExitButton()
    {
        StartCanvas.gameObject.SetActive(false);
    }
}
