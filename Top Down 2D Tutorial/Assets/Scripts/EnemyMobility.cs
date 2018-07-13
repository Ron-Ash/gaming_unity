using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour {

	public float speed;
	public Transform player;
	public Rigidbody2D enemy;
	public float enemyHealth = 100;
	public float damage;
	public GameObject health_stamina_bars;
	Health_Stamina health_stamina;
	public Collider2D playerCollider;

	void Start () 
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
	}	
	

	void FixedUpdate()
	{
		float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0, 0, z);
		enemy.AddForce(gameObject.transform.up * speed);

		if(enemyHealth<=0)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		
		if(coll.gameObject.tag == "Player")
		{
			playerCollider = coll;
			Attack();
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		playerCollider = null;
	}

	void Attack()
	{
		Debug.Log("start attack");
		//if(playerCollider?.gameObject.tag == "Player" )
		if(playerCollider && (playerCollider.gameObject.tag == "Player" ) )
		{
			if(!Input.GetMouseButton(1))
			{
				Debug.Log("hit");
				health_stamina.currentHealth -= damage;
			}
			Invoke("Attack", 2);
		}
		else
		{
			Debug.Log("wrong collider!!");		
		}
	}
}
