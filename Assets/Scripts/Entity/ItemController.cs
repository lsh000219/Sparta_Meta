using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController
{
    int itemNum, price, atk, speed;

    public ItemController(int itemNum, int price, int speed)
    {
        this.itemNum = itemNum; this.price = price; this.speed = speed;
    }

    public int ItemNum { get { return itemNum; } }
    public int Price { get { return price; } }
    public int Atk { get { return atk; } }
    public int Speed { get { return speed; } }

}
