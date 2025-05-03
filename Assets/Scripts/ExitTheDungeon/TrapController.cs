using System.Collections;
using System.Collections.Generic;
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
        exitTheDungeonManager.GameOver();
    }
}
