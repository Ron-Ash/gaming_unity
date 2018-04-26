using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];
    public Button[] InventoryButtons = new Button[10];


    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }

            if (!itemAdded)
            {
                Debug.Log("Inventory Full - Item not Added ");
            }

        }
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");
                //Update UI
                InventoryButtons[i].image.overrideSprite = null;
                break;
            }
        }
    }
}
