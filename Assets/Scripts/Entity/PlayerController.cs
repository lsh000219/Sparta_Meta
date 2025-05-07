using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    public static PlayerController instance;

    private Camera camera;
    private int gold, inven = 0, equip = 0, skinInven=1, skin = 1;
    private ItemManager itemManager;

    [SerializeField] private Sprite knight;
    [SerializeField] private Sprite elf;
    [SerializeField] private Sprite dwarf;

    [SerializeField] private RuntimeAnimatorController knightAnimator;
    [SerializeField] private RuntimeAnimatorController elfAnimator;
    [SerializeField] private RuntimeAnimatorController dwarfAnimator;
    [SerializeField] private Animator Animator;



    public void Init(GameManager gameManager)
    {
        //데이터 리셋용
        PlayerPrefs.SetInt("Gold", 1000); PlayerPrefs.Save();
        PlayerPrefs.SetInt("Inven", 0); PlayerPrefs.Save();
        PlayerPrefs.SetInt("Equip", 0); PlayerPrefs.Save();
        PlayerPrefs.SetInt("SkinInven", 1); PlayerPrefs.Save();
        PlayerPrefs.SetInt("Skin", 1); PlayerPrefs.Save();

        this.gold = PlayerPrefs.GetInt("Gold", 0);
        this.inven = PlayerPrefs.GetInt("Inven", 0);
        this.equip = PlayerPrefs.GetInt("Equip", 0);
        this.skinInven = PlayerPrefs.GetInt("SkinInven", 1);
        this.skin = PlayerPrefs.GetInt("Skin", 1);

        switch (skin)
        {
            case 1:
                characterRenderer.sprite = knight;
                Animator.runtimeAnimatorController = knightAnimator; break;
            case 2:
                characterRenderer.sprite = elf;
                Animator.runtimeAnimatorController = elfAnimator; break;
            case 4:
                characterRenderer.sprite = dwarf;
                Animator.runtimeAnimatorController = dwarfAnimator; break;
        }

        instance = this;
        itemManager = new ItemManager();
        camera = Camera.main;
    }

    public int Gold() { return gold; }

    public void PlusGold(int gold) 
    { this.gold += gold; PlayerPrefs.SetInt("Gold", this.gold); PlayerPrefs.Save(); }

    private void MinusGold(int price)
    {
        this.gold -= price;
        PlayerPrefs.SetInt("Gold", this.gold); PlayerPrefs.Save();
    }

    private void GetItem(ItemController itemController)
    {
        inven += itemController.ItemNum;

        PlayerPrefs.SetInt("Inven", inven); PlayerPrefs.Save();
    }

    public void BuyItem(ItemController itemController) //MinusGold + GetItem
    { MinusGold(itemController.Price); GetItem(itemController);}

    public bool SearchItem(int itemNum) // 인벤토리에 아이템이 있는지 확인
    {
        return (inven & itemManager.ItemController(itemNum).ItemNum) == itemManager.ItemController(itemNum).ItemNum;
    }

    public int Equip {
        get { return equip; }
        set { equip = value; PlayerPrefs.SetInt("Equip", this.equip); PlayerPrefs.Save(); }
    }



    public bool SearchSkin(int skinNum)
    {
        return (skinInven & skinNum) == skinNum;
    }

    private void GetSkin(int skinNum)
    {
        skinInven += skinNum;

        PlayerPrefs.SetInt("SkinInven", skinInven); PlayerPrefs.Save();
    }

    public void BuySkin(int skinNum)  //MinusGold + GetSkin
    { MinusGold(100); GetSkin(skinNum); }

    public int Skin
    {
        get { return skin; }
        set { skin = value; PlayerPrefs.SetInt("Skin", this.skin); PlayerPrefs.Save(); }
    }

    public void EquipSkin(int skinNum)
    {
        skin = skinNum; PlayerPrefs.SetInt("Skin", this.skin); PlayerPrefs.Save();

        switch (skin)
        {
            case 1:
                characterRenderer.sprite = knight;
                Animator.runtimeAnimatorController = knightAnimator; break;
            case 2:
                characterRenderer.sprite = elf;
                Animator.runtimeAnimatorController = elfAnimator; break;
            case 4:
                characterRenderer.sprite = dwarf;
                Animator.runtimeAnimatorController = dwarfAnimator; break;
        }
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