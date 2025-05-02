using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIManager : MonoBehaviour
{
    public enum UIState
    {
        Waiting,
        GoblinStart,
        GoblinGame,
        GoblinGameOver,
        ExitTheDungeonStart,
    }
}
