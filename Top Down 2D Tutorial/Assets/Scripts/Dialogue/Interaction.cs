using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interaction : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
	private UnityAction cancelEvent;

	void Awake()
	{
		modalPanel = ModalPanel.Instance();

		yesEvent = new UnityAction(Testbutton1);
		noEvent = new UnityAction(Testbutton2);
		cancelEvent = new UnityAction(TestCancel);
	}

	void OnMouseDown()
    {
        Debug.Log("Hello");
		if(gameObject.tag == "NPC")
		{
			Debug.Log("I dont like you!!!");
			modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", yesEvent, noEvent, cancelEvent);
		}
		else
		{
			Debug.Log(gameObject.name);
		}
    }

	void Testbutton1()
	{
		Debug.Log("Heck yeah!!!");
	}

	void Testbutton2()
	{
		Debug.Log("NOOOO!!!");
	}

	void TestCancel()
	{
		Debug.Log("I give up");
	}
}
