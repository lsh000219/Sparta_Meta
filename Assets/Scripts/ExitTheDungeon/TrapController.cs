using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private ExitTheDungeonManager exitTheDungeonManager;

    private void Awake()
    {
        this.exitTheDungeonManager = ExitTheDungeonManager.instance;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController.instance.PlusGold(exitTheDungeonManager.CheckStage());
        exitTheDungeonManager.GameOver();
    }
}
