using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	private GameObject NPC;
    private DialogueForJeff dialogueForJeff;
	private DialogueForGeorge dialogueForGeorge;

	void Start()
	{
		NPC = GameObject.FindGameObjectWithTag("NPC");
		dialogueForJeff = NPC.GetComponent<DialogueForJeff>();
		dialogueForGeorge = NPC.GetComponent<DialogueForGeorge>();
	}

	void OnMouseDown()
    {
		if(gameObject.tag == "NPC")
		{
			if(gameObject.name == "Jeff")
			{
				dialogueForJeff.Interact();
			}
			else if(gameObject.name == "George")
			{
				dialogueForGeorge.Interact();
			}
			else
			{
				Debug.Log("I dont like you!!!");
			}
		}
		else
		{
			Debug.Log(gameObject.name + " : " + gameObject.tag);
		}
    }
}
