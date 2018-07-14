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
	public GameObject playerGameObject;
	MeleeAttack meleeAttack;

	void Start () 
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		meleeAttack = playerGameObject.GetComponent<MeleeAttack>();
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
			StartAttackCounter();
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		playerCollider = null;
	}

	void DoAttack()
	{		
		if(playerCollider && playerCollider.gameObject.tag == "Player")
		{
			if(!meleeAttack.shield)
			{
				Debug.Log("hit");
				health_stamina.currentHealth -= damage;
			}
			else
			{
				health_stamina.currentStamina -= (damage*1.5f);
			}
			StartAttackCounter();
		}
		else
		{
			Debug.Log("the target escaped");		
		}
	}
	void StartAttackCounter()
	{
		if(playerCollider)
		{
			Debug.Log("start attack");
			Invoke("DoAttack", 2);
		}		
	}
}
