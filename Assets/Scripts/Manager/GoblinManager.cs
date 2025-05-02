using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class GoblinManager : GameManager
{
    public static GoblinManager instance;
    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;
    private GoblinUIManager uiManager;
    private ObjectManager objectManager;
    public static bool isFirstLoading = true;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<GoblinUIManager>();
        objectManager = FindObjectOfType<ObjectManager>();

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }

    private void Start()
    {
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        Invisible();
        uiManager.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        uiManager.ChangeWave(currentWaveIndex);
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        enemyManager.StopWave();
        uiManager.SetGameOver();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        uiManager.SetHome();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        uiManager.SetWaiting();
    }

    public void Visible()
    {
        objectManager.Visible();
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = true;
    }

    public void Invisible()
    {
        objectManager.Invisible();
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = false;
    }
}
