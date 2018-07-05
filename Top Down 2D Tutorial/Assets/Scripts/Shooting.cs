using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	public GameObject weaponsCase;
	WeaponSwiching weaponSwiching;
	public Transform firePoint;
	float timeToFire = 0;

	void Start () 
	{
		weaponsCase = GameObject.FindGameObjectWithTag("WeaponsCase");
		weaponSwiching = weaponsCase.GetComponent<WeaponSwiching>();
	}
	
	void FixedUpdate () 
	{
		if(weaponsCase.transform.childCount > 0)
		{
			if(!Input.GetKey(KeyCode.LeftShift))
			{
				if(weaponSwiching.attackRate <= 0)
				{
					if(Input.GetButtonDown("Fire"))
					{
						shoot();
					}
				}
				else
				{
					if(Input.GetButton("Fire") && Time.time>timeToFire)
					{
						timeToFire = Time.time + 1/weaponSwiching.attackRate;
						shoot();
					}
				}
			}
		}
	}

	void shoot()
	{
		if(weaponSwiching.ammo > 0 && weaponSwiching.melee == false)
		{
			Debug.Log("pewpew");
			Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
			RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, weaponSwiching.range, weaponSwiching.hit);
			Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);
			weaponSwiching.ammo--;

			if(hit.collider != null)
			{
				Debug.Log("hello");
			}

		}
		else if(weaponSwiching.melee == true)
		{
			Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
			RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, weaponSwiching.range, weaponSwiching.hit);
			Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);
			if(hit.collider != null)
			{
				Debug.Log("hello");
			}
		}
	}
}
