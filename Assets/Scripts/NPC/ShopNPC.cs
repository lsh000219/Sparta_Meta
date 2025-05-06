using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
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
        button1.onClick.AddListener(() => Trade(1));
        button2.onClick.AddListener(() => Trade(2));
        button4.onClick.AddListener(() => Trade(3));
        button8.onClick.AddListener(() => Trade(4));
        button16.onClick.AddListener(() => Trade(5));
    }

    private void Update()
    {
        if (PlayerController.instance.SearchItem(1)) { button11.text = "Sold Out"; } else { button11.text = "Buy"; }
        if (PlayerController.instance.SearchItem(2)) { button22.text = "Sold Out"; } else { button22.text = "Buy"; }
        if (PlayerController.instance.SearchItem(3)) { button44.text = "Sold Out"; } else { button44.text = "Buy"; }
        if (PlayerController.instance.SearchItem(4)) { button88.text = "Sold Out"; } else { button88.text = "Buy"; }
        if (PlayerController.instance.SearchItem(5)) { button1616.text = "Sold Out"; } else { button1616.text = "Buy"; }
    }

    public void Trade(int itemNum) { if (PlayerController.instance.Gold() >= itemManager.ItemController(itemNum).Price && !PlayerController.instance.SearchItem(itemNum)) {
            PlayerController.instance.BuyItem(itemManager.ItemController(itemNum)); 
        } }
}
