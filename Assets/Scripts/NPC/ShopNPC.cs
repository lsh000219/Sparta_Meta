using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShopNPC : BaseNPC
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;
    [SerializeField] private Button button8;
    [SerializeField] private Button button16;

    [SerializeField] public TextMeshProUGUI button11;
    [SerializeField] public TextMeshProUGUI button22;
    [SerializeField] public TextMeshProUGUI button44;
    [SerializeField] public TextMeshProUGUI button88;
    [SerializeField] public TextMeshProUGUI button1616;

    ItemManager itemManager;

    private void Start()
    {
        itemManager = new ItemManager();
        button1.onClick.AddListener(() => Trade(0));
        button2.onClick.AddListener(() => Trade(1));
        button4.onClick.AddListener(() => Trade(2));
        button8.onClick.AddListener(() => Trade(3));
        button16.onClick.AddListener(() => Trade(4));
    }

    private void Update()
    {
        if (PlayerController.instance.SearchItem(1)) { button11.text = "Sold Out"; }
        if (PlayerController.instance.SearchItem(2)) { button22.text = "Sold Out"; }
        if (PlayerController.instance.SearchItem(4)) { button44.text = "Sold Out"; }
        if (PlayerController.instance.SearchItem(8)) { button88.text = "Sold Out"; }
        if (PlayerController.instance.SearchItem(16)) { button1616.text = "Sold Out"; }
    }

    public void Trade(int itemNum) { if (PlayerController.instance.Gold() > 100) {
            PlayerController.instance.BuyItem(itemManager.ItemController(itemNum)); 
        } }
}
