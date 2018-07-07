using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public Rigidbody2D player;
	public bool moving = false;
	
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
