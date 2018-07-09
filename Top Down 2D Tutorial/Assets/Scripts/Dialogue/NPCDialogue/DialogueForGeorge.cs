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
	private UnityAction cancelEvent2;

	void Awake()
	{
		modalPanel = ModalPanel.Instance();

		yesEvent = new UnityAction(Yes);
		noEvent = new UnityAction(No);
		cancelEvent = new UnityAction(Cancel);

		yesEvent2 = new UnityAction(Yes2);
		noEvent2 = new UnityAction(No2);
		cancelEvent2 = new UnityAction(Cancel2);
	}

	public void Interact()
	{
		modalPanel.Choice("Hey my freind\nDo you want food?", yesEvent, noEvent, cancelEvent);
	}
	
	void Yes()
	{
		modalPanel.Choice("ok...\nIs this better?", yesEvent2, noEvent2, cancelEvent2);
		Debug.Log("Heck yeah!!!");
	}

	void No()
	{
		modalPanel.Choice("are you sure?", yesEvent2, noEvent2, cancelEvent2);
		Debug.Log("NOOOO!!!");
	}

	void Cancel()
	{
		Debug.Log("Im good cya");
		modalPanel.closePanel();
	}

	void Yes2()
	{
		Debug.Log("yep");
		modalPanel.closePanel();
	}

	void No2()
	{
		Debug.Log("Nah");
		modalPanel.closePanel();
	}

	void Cancel2()
	{
		Debug.Log("Cya");
		modalPanel.closePanel();
	}
}
