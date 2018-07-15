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
	}

	void OnMouseDown()
    {
		if(gameObject.tag == "NPC")
		{
			if(gameObject.name == "Jeff")
			{
				gameObject.AddComponent<DialogueForJeff>();
				dialogueForJeff = gameObject.GetComponent<DialogueForJeff>();
				dialogueForJeff.Interact();
			}
			else if(gameObject.name == "George")
			{
				gameObject.AddComponent<DialogueForGeorge>();
				dialogueForGeorge = gameObject.GetComponent<DialogueForGeorge>();
				dialogueForGeorge.Interact();
			}
			else
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
