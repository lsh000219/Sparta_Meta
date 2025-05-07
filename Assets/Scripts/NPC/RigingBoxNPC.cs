using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BoxNPC : BaseNPC
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;
    [SerializeField] private Button button8;
    [SerializeField] private Button button16;
    [SerializeField] private Button button0;

    [SerializeField] public TextMeshProUGUI button11;
    [SerializeField] public TextMeshProUGUI button22;
    [SerializeField] public TextMeshProUGUI button44;
    [SerializeField] public TextMeshProUGUI button88;
    [SerializeField] public TextMeshProUGUI button1616;

    [SerializeField] private Transform RidingPivot;
    [SerializeField] private GameObject Zom;
    [SerializeField] private GameObject Imp;
    [SerializeField] private GameObject Pum;
    [SerializeField] private GameObject Gob;
    [SerializeField] private GameObject Liz;

    private GameObject Riding;

    private void Start()
    {
        button0.onClick.AddListener(() => Equip(0));
        button1.onClick.AddListener(() => Equip(1));
        button2.onClick.AddListener(() => Equip(2));
        button4.onClick.AddListener(() => Equip(4));
        button8.onClick.AddListener(() => Equip(8));
        button16.onClick.AddListener(() => Equip(16));
        Equip(PlayerController.instance.Equip);
    }

    private void Update()
    {
        if (!PlayerController.instance.SearchItem(1)) { button1.gameObject.SetActive(false);  }else { button1.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchItem(2)) { button2.gameObject.SetActive(false); } else { button2.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchItem(3)) { button4.gameObject.SetActive(false); } else { button4.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchItem(4)) { button8.gameObject.SetActive(false); } else { button8.gameObject.SetActive(true); }
        if (!PlayerController.instance.SearchItem(5)) { button16.gameObject.SetActive(false); } else { button16.gameObject.SetActive(true); }

        if (PlayerController.instance.Equip == 1) { button11.text = "Equipped"; } else { button11.text = "Equip"; }
        if (PlayerController.instance.Equip == 2) { button22.text = "Equipped"; } else { button22.text = "Equip"; }
        if (PlayerController.instance.Equip == 4) { button44.text = "Equipped"; } else { button44.text = "Equip"; }
        if (PlayerController.instance.Equip == 8) { button88.text = "Equipped"; } else { button88.text = "Equip"; }
        if (PlayerController.instance.Equip == 16) { button1616.text = "Equipped"; } else { button1616.text = "Equip"; }
    }

    private void Equip(int i) { 
        PlayerController.instance.Equip = i; 

        switch (i)
        {
            case 0:
                Destroy(Riding);
                break;
            case 1:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Zom, RidingPivot);
                break;
            case 2:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Imp, RidingPivot);
                break;
            case 4:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Pum, RidingPivot);
                break;
            case 8:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Gob, RidingPivot);
                break;
            case 16:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Liz, RidingPivot);
                break;
        }
    }
}
