using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : BaseNPC
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;
    [SerializeField] private Button button8;
    [SerializeField] private Button button16;

    private void Start()
    {
        button1.onClick.AddListener(() => Trade(1));
        button2.onClick.AddListener(() => Trade(2));
        button4.onClick.AddListener(() => Trade(4));
        button8.onClick.AddListener(() => Trade(8));
        button16.onClick.AddListener(() => Trade(16));
    }

    public void Trade(int itemNum) { if (PlayerController.instance.Gold() < 100) { 
            //PlayerController.instance.BuyItem(100, itemNum); 
        } }
}
