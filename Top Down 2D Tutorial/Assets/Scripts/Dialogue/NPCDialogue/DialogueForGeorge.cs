using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForGeorge : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
	private UnityAction cancelEvent;
	private UnityAction yesEvent2;
	private UnityAction noEvent2;
	
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
	}

	public void Interact()
	{
		modalPanel.Choice("Hey my freind\nDo you want food?", yesEvent, noEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "yes";
		modalPanel.button2.GetComponentInChildren<Text>().text = "no";
	}
	
	void Yes()
	{
		health_stamina.currentHealth = health_stamina.currentHealth + 25;
		modalPanel.Choice("ok...\nIs this better?", yesEvent2, yesEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "yes it is thank you";
		modalPanel.button2.GetComponentInChildren<Text>().text = "no, i need more";
		Debug.Log("Heck yeah!!!");
	}

	void No()
	{
		modalPanel.Choice("are you sure?", yesEvent2, yesEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "yes";
		modalPanel.button2.GetComponentInChildren<Text>().text = "actually, I want some food thanks";
		Debug.Log("NOOOO!!!");
	}

	void Cancel()
	{
		NPCText.text = "what a nice person";
		modalPanel.closePanel();
	}

	void Yes2()
	{
		NPCText.text = "what a nice person";
		modalPanel.closePanel();
	}
}
