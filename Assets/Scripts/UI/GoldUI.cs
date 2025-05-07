using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goldText;

    private void Update()
    {
        goldText.text = (PlayerController.instance.Gold()).ToString();
    }
}
