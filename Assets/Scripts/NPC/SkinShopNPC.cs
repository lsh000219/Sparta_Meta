using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopNPC : BaseNPC
{
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;

    [SerializeField] public TextMeshProUGUI button22;
    [SerializeField] public TextMeshProUGUI button44;

    private void Start()
    {
        button2.onClick.AddListener(() => Trade(2));
        button4.onClick.AddListener(() => Trade(4));
    }

    private void Update()
    {
        if (PlayerController.instance.SearchSkin(2)) { button22.text = "Sold Out"; } else { button22.text = "Buy"; }
        if (PlayerController.instance.SearchSkin(4)) { button44.text = "Sold Out"; } else { button44.text = "Buy"; }
    }

    public void Trade(int itemNum)
    {
        if (PlayerController.instance.Gold() >= 100 && !PlayerController.instance.SearchSkin(itemNum))
        {
            PlayerController.instance.BuySkin(itemNum);
        }
    }
}
