using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldManNPC : MonoBehaviour
{
    [SerializeField] private GameObject oldManCanvas;

    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button topButton;
    [SerializeField] private Button bottomButton;

    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI topText;
    [SerializeField] private TextMeshProUGUI bottomText;

    [SerializeField] private Button exitButton;


    private void Awake()
    {
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Start()
    {
        rightButton.onClick.AddListener(() => TextSetActive(1));
        leftButton.onClick.AddListener(() => TextSetActive(2));
        topButton.onClick.AddListener(() => TextSetActive(3));
        bottomButton.onClick.AddListener(() => TextSetActive(4));
    }

    public void OnCollisionEnter2D(Collision2D collision) { oldManCanvas.gameObject.SetActive(true); }

    public void OnClickExitButton() { TextSetActive(0); oldManCanvas.gameObject.SetActive(false); }

    private void TextSetActive(int i)
    {
        Text.gameObject.SetActive(0 == i);
        rightText.gameObject.SetActive(1 == i);
        leftText.gameObject.SetActive(2 == i);
        topText.gameObject.SetActive(3 == i);
        bottomText.gameObject.SetActive(4 == i);
    }
}
