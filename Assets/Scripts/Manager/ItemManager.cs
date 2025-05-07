using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private List<ItemController> inventory;

    public ItemManager() {  
        inventory = new List<ItemController>();
        inventory.Add(new ItemController(0, 100, 3));
        inventory.Add(new ItemController(1, 100, 5));
        inventory.Add(new ItemController(2, 100, 7));
        inventory.Add(new ItemController(4, 100, 9));
        inventory.Add(new ItemController(8, 100, 11));
        inventory.Add(new ItemController(16, 100, 13));
    }

    public int ItemStatSpeed(int i) { 
        if (i > 0) { return inventory[(int)Mathf.Log(i, 2)+1].Speed; }
        else { return inventory[0].Speed; }
         }

    public ItemController ItemController(int id) {  return inventory[id]; }
}
