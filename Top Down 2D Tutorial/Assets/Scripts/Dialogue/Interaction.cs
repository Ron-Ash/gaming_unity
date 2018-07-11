using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	private GameObject NPC;
    private DialogueForJeff dialogueForJeff;
	private DialogueForGeorge dialogueForGeorge;
	private Text NPCText;

	void Start()
	{
		NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();
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

			if(gameObject.name == "George")
			{
				dialogueForGeorge.Interact();
			}

			if (gameObject.name == "NPC")
			{
				NPCText.text = "He doesn't seem freindly, better stay away";
			}
		}
		else
		{
			NPCText.text = gameObject.name + " : " + gameObject.tag;
		}
    }
}
