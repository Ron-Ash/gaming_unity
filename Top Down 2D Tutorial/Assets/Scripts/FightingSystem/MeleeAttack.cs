using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public GameObject weaponsCase;
	WeaponSwiching weaponSwiching;
	EnemyMobility enemyMobility;
	public GameObject enemy;

	void Start () 
	{
		weaponsCase = GameObject.FindGameObjectWithTag("WeaponsCase");
		weaponSwiching = weaponsCase.GetComponent<WeaponSwiching>();
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyMobility = enemy.GetComponent<EnemyMobility>();
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		
		if(weaponsCase.transform.childCount > 0)
		{
			if(!Input.GetKey(KeyCode.LeftShift))
			{
			
				if(Input.GetButtonDown("Fire") && coll.gameObject.tag == "Enemy")
				{
					shoot();
				}
			}
		}
	}

	void shoot()
	{
		Debug.Log("swing...swoosh");
		enemyMobility.enemyHealth = enemyMobility.enemyHealth - weaponSwiching.damage;
	}
}
