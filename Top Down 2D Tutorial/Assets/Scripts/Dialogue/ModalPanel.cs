using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

	public Text question;
	public Image iconImage;
	public Button button1;
	public Button button2;
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

	// Yes/No/Cancel: A string, a yes event, a no event, a cancel event
	public void Choice(string question , UnityAction yesEvent, UnityAction noEvent, UnityAction calcelEvent)
	{
		modalPanelObject.SetActive(true);

		button1.onClick.RemoveAllListeners();
		button1.onClick.AddListener(yesEvent);
		button1.onClick.AddListener(closePanel);

		button2.onClick.RemoveAllListeners();
		button2.onClick.AddListener(noEvent);
		button1.onClick.AddListener(closePanel);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(calcelEvent);
		cancelButton.onClick.AddListener(closePanel);

		this.question.text = question;
		this.iconImage.gameObject.SetActive(false);
		button1.gameObject.SetActive(true);
		button2.gameObject.SetActive(true);
		cancelButton.gameObject.SetActive(true);
	}

	void closePanel()
	{
		modalPanelObject.SetActive(false);
	}

}
