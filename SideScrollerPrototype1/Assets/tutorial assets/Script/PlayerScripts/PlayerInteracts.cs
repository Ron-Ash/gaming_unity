using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracts : MonoBehaviour {

    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjectScript = null;
    public PlayerInventory inventory;

    private void Update()
    {
        if (Input.GetButton("Interact") && currentInterObject)
        {
            if (currentInterObjectScript.inventory)
            {
                inventory.AddItem(currentInterObject);
            }
        }

        if (Input.GetButton("Interact") && currentInterObject)
        {
            Debug.Log("interacted with " + currentInterObject.name);
        }
    }
    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            Debug.Log(other.name);
            currentInterObject = other.gameObject;
            currentInterObjectScript = currentInterObject.GetComponent <InteractionObject>();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            if (other.gameObject == currentInterObject)
            {
                currentInterObject = null;
            }          
        }     
    }
}
