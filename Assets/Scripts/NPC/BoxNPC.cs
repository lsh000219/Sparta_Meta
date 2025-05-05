using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxNPC : BaseNPC
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button4;
    [SerializeField] private Button button8;
    [SerializeField] private Button button16;

    private void Start()
    {
        button1.onClick.AddListener(() => Equip(1));
        button2.onClick.AddListener(() => Equip(2));
        button4.onClick.AddListener(() => Equip(4));
        button8.onClick.AddListener(() => Equip(8));
        button16.onClick.AddListener(() => Equip(16));
    }

    public void Equip(int i)
    {
        //PlayerController에 i 주기
    }

}
