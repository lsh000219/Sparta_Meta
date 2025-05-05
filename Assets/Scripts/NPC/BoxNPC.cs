using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxNPC : BaseNPC
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

    private void Start()
    {
        button1.onClick.AddListener(() => Equip(1));
        button2.onClick.AddListener(() => Equip(2));
        button4.onClick.AddListener(() => Equip(4));
        button8.onClick.AddListener(() => Equip(8));
        button16.onClick.AddListener(() => Equip(16));
    }

    private void Update()
    {
        if (!PlayerController.instance.SearchItem(1)) { button1.gameObject.SetActive(false); }
        if (!PlayerController.instance.SearchItem(2)) { button2.gameObject.SetActive(false); }
        if (!PlayerController.instance.SearchItem(4)) { button4.gameObject.SetActive(false); }
        if (!PlayerController.instance.SearchItem(8)) { button8.gameObject.SetActive(false); }
        if (!PlayerController.instance.SearchItem(16)) { button16.gameObject.SetActive(false); }

        if (PlayerController.instance.Equip == 1) { button11.text = "Equipped"; }
        if (PlayerController.instance.Equip == 2) { button22.text = "Equipped"; }
        if (PlayerController.instance.Equip == 4) { button44.text = "Equipped"; }
        if (PlayerController.instance.Equip == 8) { button88.text = "Equipped"; }
        if (PlayerController.instance.Equip == 16) { button1616.text = "Equipped"; }
    }

    private void Equip(int i) { PlayerController.instance.Equip = i; }

}
