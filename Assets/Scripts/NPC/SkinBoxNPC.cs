using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinBoxNPC : BaseNPC
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;

    [SerializeField] public TextMeshProUGUI button11;
    [SerializeField] public TextMeshProUGUI button22;
    [SerializeField] public TextMeshProUGUI button44;

    [SerializeField] private Transform MainSprite;
    [SerializeField] private GameObject Knight;
    [SerializeField] private GameObject Elf;
    [SerializeField] private GameObject Dwarf;


    private GameObject skin;

    private void Start()
    {
        button1.onClick.AddListener(() => Equip(1));
        button2.onClick.AddListener(() => Equip(2));
        button4.onClick.AddListener(() => Equip(4));
    }

    private void Update()
    {
        if (!PlayerController.instance.SearchSkin(1)) { button1.gameObject.SetActive(false); } else { button1.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchSkin(2)) { button2.gameObject.SetActive(false); } else { button2.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchSkin(4)) { button4.gameObject.SetActive(false); } else { button4.gameObject.SetActive(true); }
        
        if (PlayerController.instance.Skin == 1) { button11.text = "Equipped"; } else { button11.text = "Equip"; }
        if (PlayerController.instance.Skin == 2) { button22.text = "Equipped"; } else { button22.text = "Equip"; }
        if (PlayerController.instance.Skin == 4) { button44.text = "Equipped"; } else { button44.text = "Equip"; }
    }

    private void Equip(int i)
    {

        switch (i)
        {
            case 1:
                PlayerController.instance.EquipSkin(1); break;
            case 2:
                PlayerController.instance.EquipSkin(2); break;
            case 4:
                PlayerController.instance.EquipSkin(4); break;
        }
    }
}
