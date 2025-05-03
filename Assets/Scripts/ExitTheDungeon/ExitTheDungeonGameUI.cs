using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ExitTheDungeonGameUI : MonoBehaviour
{
    private int stage = 0;
    public TextMeshProUGUI stageText;
    private Canvas GameCanvas;

    public void Awake() { GameCanvas = transform.Find("StageUI").GetComponent<Canvas>(); }

    private int Stage { get { return stage; } set { stage = value; } }

    public void ExitTheDungeonGameUIOnOff(bool swit) { GameCanvas.gameObject.SetActive(swit); }

    public void ChangeStage(int stage) { this.Stage = stage; stageText.text = stage.ToString(); }
}
