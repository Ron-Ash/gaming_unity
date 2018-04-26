using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventory; //if the item true added into inventory
    public bool NPC;



    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    
}
