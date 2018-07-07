using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health_Stamina : MonoBehaviour {

	public float currentHealth;
	float maxHealth = 500.0f;
	public float currentStamina;
	float maxStamina = 500.0f;
	public Transform HealthMeter;
    public Transform StaminaMeter;

	void Start () 
	{
		currentHealth = maxHealth;
		currentStamina = maxStamina;
		HealthMeter.GetComponent<Image>().color = new Color(0, 1, 0);
	}
	
	void FixedUpdate ()
	{
		if (currentHealth < 251)
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 1, 0);
        }

        if (currentHealth < 101)
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 0, 0);
        }

		if (currentHealth == 0)
        {
            SceneManager.LoadScene(0);
        }
		
		if(currentStamina<maxStamina)
		{
			currentStamina = currentStamina+0.5f;
		}

		HealthMeter.GetComponent<RectTransform>().localScale = new Vector3(currentHealth / maxHealth, 1, 1);

        StaminaMeter.GetComponent<RectTransform>().localScale = new Vector3(currentStamina / maxStamina, 1, 1);	
	}
}
