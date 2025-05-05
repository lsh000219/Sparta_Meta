using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseNPC : MonoBehaviour
{
    private Canvas Canvas;
    [SerializeField] private Button exitButton;

    private void Awake() { 
        Canvas = transform.Find("UI").GetComponent<Canvas>(); 
        exitButton.onClick.AddListener(OnClickExitButton); 
    }

    public void OnCollisionEnter2D(Collision2D collision) { Canvas.gameObject.SetActive(true); }

    public void OnClickExitButton()
    {
        Canvas.gameObject.SetActive(false);
    }
}
