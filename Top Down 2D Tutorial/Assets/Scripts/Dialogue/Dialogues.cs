using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Dialogues : MonoBehaviour {

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

		yesEvent = new UnityAction(Testbutton1);
		noEvent = new UnityAction(Testbutton2);
		cancelEvent = new UnityAction(TestCancel);

		yesEvent2 = new UnityAction(Testbutton12);
		noEvent2 = new UnityAction(Testbutton22);
		cancelEvent2 = new UnityAction(TestCancel2);
	}

	public void Interact()
	{
		modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", yesEvent, noEvent, cancelEvent);
	}
	
	void Testbutton1()
	{
		modalPanel.Choice("ok", yesEvent2, noEvent2, cancelEvent2);
		Debug.Log("Heck yeah!!!");
	}

	void Testbutton2()
	{
		modalPanel.Choice("are you sure?", yesEvent2, noEvent2, cancelEvent2);
		Debug.Log("NOOOO!!!");
	}

	void TestCancel()
	{
		Debug.Log("I give up");
		modalPanel.closePanel();
	}

	void Testbutton12()
	{
		Debug.Log("yep");
		modalPanel.closePanel();
	}

	void Testbutton22()
	{
		Debug.Log("Nah");
		modalPanel.closePanel();
	}

	void TestCancel2()
	{
		Debug.Log("f*#k you");
		modalPanel.closePanel();
	}
}
