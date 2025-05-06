using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private int currentWaveIndex = 0;
    [SerializeField] private GobNKnight gobNKnight;
    [SerializeField] private Door door;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;
    private EnemyManager enemyManager;
    private GoblinUIManager uiManager;
    
    public static bool isFirstLoading = true;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<GoblinUIManager>();
        _playerResourceController = PlayerController.instance.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }

    public int CurrentWaveIndex() { return currentWaveIndex; }

    public void StartGame()
    {
        currentWaveIndex = 0;
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
        if (currentWaveIndex > PlayerPrefs.GetInt("BestWave", 0))
        {
            PlayerPrefs.SetInt("BestWave", currentWaveIndex); PlayerPrefs.Save();
        }
        player.PlusGold(currentWaveIndex);
        enemyManager.StopWave();
        uiManager.SetGameOver();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        uiManager.SetHome();
    }


    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    uiManager.SetWaiting();
    //}

    public void Visible()
    {
        gobNKnight.Visible();
        door.Invisible();
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = true;
    }

    public void Invisible()
    {
        gobNKnight.Invisible();
        door.Visible();
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = false;
    }
}
