using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour {

	public float speed;
	public Transform player;
	public Rigidbody2D enemy;
	public float enemyHealth = 100;

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
}
