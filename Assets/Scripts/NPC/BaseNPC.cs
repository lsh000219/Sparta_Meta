using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseNPC : MonoBehaviour
{
    private Canvas Canvas;
    [SerializeField] private Button exitButton;
    [SerializeField] private Canvas canvas;

    private void Awake() { 
        exitButton.onClick.AddListener(OnClickExitButton); 
    }

    public void OnCollisionEnter2D(Collision2D collision) { canvas.gameObject.SetActive(true); }

    public void OnClickExitButton() { canvas.gameObject.SetActive(false); }
}
