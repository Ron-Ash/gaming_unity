using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

	public Text question;
	public Image iconImage;
	public Button noButton;
	//public Button noButton;
	public Button cancelButton;
	public GameObject modalPanelObject;

	private static ModalPanel modalPanel;

	public static ModalPanel Instance()
	{
		if(!modalPanel)
		{
			modalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
			if(!modalPanel)
			{
				Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
			}
		}
		return modalPanel;
	}

	// Yes/No/Cancel: A string
	public void Choice(string question , UnityAction yesEvent, UnityAction noEvent, UnityAction calcelEvent)
	{

	}

}
