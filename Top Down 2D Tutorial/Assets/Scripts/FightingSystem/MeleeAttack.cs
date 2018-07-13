using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public GameObject weaponsCase;
	WeaponSwiching weaponSwiching;
	EnemyMobility enemyMobility;
	public GameObject enemy;
	public GameObject health_stamina_bars;
	Health_Stamina health_stamina;

	void Start () 
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
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
			
				if(Input.GetButtonDown("Fire") && coll.gameObject.tag == "Enemy" && health_stamina.currentStamina > 0)
				{
					shoot();
				}
			}
		}
	}

	void shoot()
	{
		Debug.Log("swing...swoosh");
		enemyMobility.enemyHealth -= weaponSwiching.damage;
		health_stamina.currentStamina -= weaponSwiching.attackRate;
	}
}
