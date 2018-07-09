using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	private GameObject NPC;
    private Dialogues dialogues;

	void Awake()
	{
		NPC = GameObject.FindGameObjectWithTag("NPC");
		dialogues = NPC.GetComponent<Dialogues>();
	}

	void OnMouseDown()
    {
		if(gameObject.tag == "NPC")
		{
			Debug.Log("I dont like you!!!");
			dialogues.Interact();
		}
		else
		{
			Debug.Log(gameObject.name + " : " + gameObject.tag);
		}
    }
}
