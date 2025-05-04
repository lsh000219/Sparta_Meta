using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ExitTheDungeonManager : GameManager
{
    public static ExitTheDungeonManager instance;
    int stage = 1;

    public ExitTheDungeonPlayerController player { get; private set; }
    private ExitTheDungeonGameUI exitTheDungeonGameUI;
    private ExitTheDungeonGameOverUI exitTheDungeonGameOverUI;
    private TrapManager trapManager;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<ExitTheDungeonPlayerController>(); player.Init();
        trapManager = FindObjectOfType<TrapManager>();
        exitTheDungeonGameUI = FindObjectOfType<ExitTheDungeonGameUI>();
        exitTheDungeonGameOverUI = FindObjectOfType<ExitTheDungeonGameOverUI>();
        exitTheDungeonGameUI.ExitTheDungeonGameUIOnOff(true);
        GameStart();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        stage++;
        player.transform.position = new Vector2(-5f, -1.2f);
        trapManager.EraseTrap(); trapManager.StartStage(stage);
    }

    public void GameStart()
    {
        stage = 1;
        player.IsDead(false); player.transform.position = new Vector2(-5f, -1.2f);
        trapManager.StartStage(stage);
    }

    public void GameOver() { trapManager.EraseTrap(); player.IsDead(true); exitTheDungeonGameOverUI.GameOverUI(); }
}
