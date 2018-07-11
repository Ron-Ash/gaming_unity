using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public float sprint;
	public float lightSprint;
	public float tiredSprint;
	public Rigidbody2D player;
	public bool moving = false;
	public GameObject health_stamina_bars;
	Health_Stamina health_stamina;

	void Awake()
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		sprint = speed*2;
		lightSprint = sprint-0.5f;
		tiredSprint = sprint/1.5f;
	}
	
	void FixedUpdate()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		player.angularVelocity = 0;

		if(moving == true)
		{
			movment();
		}
		else
		{
			checkMovment();
		}

		if(Input.GetKey(KeyCode.Space) && health_stamina.currentStamina > 0)
		{
			if(health_stamina.currentStamina<150)
			{
				speed = lightSprint;
				health_stamina.currentStamina = health_stamina.currentStamina-1.5f;
			}
			else if(health_stamina.currentStamina<50)
			{
				speed = tiredSprint;
				health_stamina.currentStamina = health_stamina.currentStamina-1;
			}
			else
			{
				speed = sprint;
				health_stamina.currentStamina = health_stamina.currentStamina-2;
			}
		}
		else
		{
			speed = sprint/2;
		}

		if(Input.GetKey(KeyCode.Space) && health_stamina.currentStamina <= 0.5f)
		{
			speed = sprint/2.5f;
			health_stamina.currentHealth = health_stamina.currentHealth-0.1f;
		}
	}

	void checkMovment()
	{
		if(Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true)
		{
			moving = false;
		}
		else
		{
			moving = true;
		}
	}

	public void setMoving(bool val)
	{
		moving = val;
	}

	void movment()
	{	
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime,Space.World);
			moving = true;
		}

		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime,Space.World);
			moving = true;
		}

		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
			moving = true;
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
			moving = true;
		}

		if(Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true)
		{
			moving = false;
		}		
	}
}
