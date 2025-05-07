using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitTheDungeonGameOverUI : MonoBehaviour
{
    private Canvas GameOverCanvas;
    private ExitTheDungeonGameUI exitTheDungeonGameUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI stageText;

    private void Awake()
    {
        GameOverCanvas = transform.Find("GameOverUI").GetComponent<Canvas>();
        exitTheDungeonGameUI = FindObjectOfType<ExitTheDungeonGameUI>();
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void SetStageText(int i) {  stageText.text = i.ToString(); }

    public void GameOverUI()
    {
        GameOverCanvas.gameObject.SetActive(true);
    }

    private void OnClickRestartButton() { ExitTheDungeonManager.instance.GameStart(); GameOverCanvas.gameObject.SetActive(false); }

    private void OnClickExitButton() { SceneManager.LoadScene("MainScene"); GameOverCanvas.gameObject.SetActive(false); exitTheDungeonGameUI.ExitTheDungeonGameUIOnOff(false); }
}
