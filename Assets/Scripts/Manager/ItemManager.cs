using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private List<ItemController> inventory;

    public ItemManager() {  
        inventory = new List<ItemController>();
        inventory = new List<ItemController>();
        inventory.Add(new ItemController(0, 100, 0, 0));
        inventory.Add(new ItemController(1, 100, 0, 5));
        inventory.Add(new ItemController(2, 100, 0, 3));
        inventory.Add(new ItemController(4, 100, 0, 5));
        inventory.Add(new ItemController(8, 100, 0, 7));
        inventory.Add(new ItemController(16, 100, 0, 9));
    }

    public int ItemStatAtk(int i) { return inventory[(int)Mathf.Log(i, 2)].Atk; }

    public int ItemStatSpeed(int i) {  
        if(i == 0) { return 0; }
        return inventory[(int)Mathf.Log(i, 2)+1].Speed; }

    public ItemController ItemController(int id) {  return inventory[id]; }
}
