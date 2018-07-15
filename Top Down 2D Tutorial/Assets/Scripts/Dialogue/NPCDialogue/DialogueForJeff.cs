using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForJeff : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
	private UnityAction cancelEvent;
	private UnityAction yesEvent2;
	private UnityAction cancelEvent2;

	private Text NPCText;
	private GameObject health_stamina_bars;
	Health_Stamina health_stamina;

	void Awake()
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();

		modalPanel = ModalPanel.Instance();

		yesEvent = new UnityAction(Yes);
		noEvent = new UnityAction(No);
		cancelEvent = new UnityAction(Cancel);

		yesEvent2 = new UnityAction(Yes2);
		cancelEvent2 = new UnityAction(Cancel2);
	}

	public void Interact()
	{
		modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", yesEvent, noEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "yes";
		modalPanel.button2.GetComponentInChildren<Text>().text = "no";
	}
	
	void Yes()
	{
		modalPanel.Choice("ok...stay still...", yesEvent2, noEvent, cancelEvent2);
		modalPanel.button1.gameObject.SetActive(false);
		modalPanel.button2.gameObject.SetActive(false);
		NPCText.text = "Ouch, that hurts...";
		health_stamina.currentHealth = health_stamina.currentHealth  - 50;
	}

	void No()
	{
		modalPanel.Choice("are you sure?", yesEvent2, yesEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "yes I am sure";
		modalPanel.button2.GetComponentInChildren<Text>().text = "Actually, I do want a poke in the eye";
	}

	void Cancel()
	{
		NPCText.text = "what a starnge person";
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForJeff>());
	}

	void Yes2()
	{
		NPCText.text = "what a starnge person";
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForJeff>());
	}

	void Cancel2()
	{
		Debug.Log("f*#k you");
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForJeff>());
	}
}
