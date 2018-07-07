using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	public Collider2D npnCollider;

	void OnMouseDown()
    {
        if(npnCollider.gameObject.tag == "NPC")
		{
			Debug.Log("I dont like you!!!");
		}
    }
}
