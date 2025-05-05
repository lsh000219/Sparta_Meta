using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    public static PlayerController instance;

    private Camera camera;
    private int gold, inven = 0, equip = 0, skin = 0;
    private ItemManager itemManager;

    public void Init(GameManager gameManager)
    {
        
        this.gold = PlayerPrefs.GetInt("Gold", 0);
        this.inven = PlayerPrefs.GetInt("Inven", 0);
        this.equip = PlayerPrefs.GetInt("Equip", 0);
        instance = this;
        itemManager = new ItemManager();
        camera = Camera.main;
    }

    public int Gold() { return gold; }

    public void PlusGold(int gold) 
    { this.gold += gold; PlayerPrefs.SetInt("Gold", this.gold); PlayerPrefs.Save(); }

    public void BuyItem(ItemController itemController) 
    { MinusGold(itemController.Price); GetItem(itemController);}

    private void MinusGold(int price) 
    { 
        this.gold -= price; 
        PlayerPrefs.SetInt("Gold", this.gold); PlayerPrefs.Save(); 
    }

    private void GetItem(ItemController itemController) { 
        inven += itemController.ItemNum; 
        //inventory.Add(itemController); 
        PlayerPrefs.SetInt("Inven", this.inven); PlayerPrefs.Save();
    }

    public bool SearchItem(int itemNum) // 인벤토리에 아이템이 있는지 확인
    {
        if ((inven & itemNum) == itemNum) return true;
        else return false;
    }

    public int Equip {
        get { return equip; }
        set { equip = value; PlayerPrefs.SetInt("Equip", this.equip); PlayerPrefs.Save(); }
    }

    public int ItemStatSpeed() { return itemManager.ItemStatSpeed(equip); } 

    protected override void HandleAction()
    {
        camera = Camera.main;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        isAttacking = Input.GetMouseButton(0);
    }

    public override void Death()
    {
        base.Death();
        GameManager.instance.GameOver();
    }

    public void ExitGoblin() { transform.position = new Vector2(0f, 8.18f); } //고블린 게임 종료 후 위치 이동

    //private void DeleteData()
    //{
    //    PlayerPrefs.DeleteKey("Gold");
    //    PlayerPrefs.DeleteKey("Inven");
    //}
}