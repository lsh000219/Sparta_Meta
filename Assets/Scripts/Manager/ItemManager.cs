using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private List<ItemController> inventory;

    public ItemManager() {  
        inventory = new List<ItemController>();
        inventory = new List<ItemController>();
        inventory.Add(new ItemController(1, 100, 1, 1));
        inventory.Add(new ItemController(2, 100, 1, 1));
        inventory.Add(new ItemController(4, 100, 1, 1));
        inventory.Add(new ItemController(8, 100, 1, 1));
        inventory.Add(new ItemController(16, 100, 1, 1));
    }
    

    public ItemController ItemController(int id) {  return inventory[id]; }
}
