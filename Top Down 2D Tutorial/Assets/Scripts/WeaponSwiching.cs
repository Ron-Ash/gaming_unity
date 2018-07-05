using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwiching : MonoBehaviour {

	public int selectedWeapon = 0;
	public Text weaponName;
	WeaponsStatsPickUp weaponsStatsPickUp;
	public float attackRate;
	public float damage;
	public float range;
	public bool melee;
	public float ammo;
	public float clipSize;
	public LayerMask hit;

	void Start () 
	{
		selectWeapon();
	}
	

	void Update () 
	{
		int previousSelectedWeapon = selectedWeapon;

		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if(selectedWeapon >= transform.childCount - 1)
			{
				selectedWeapon = 0;
			}
			else
			{
				selectedWeapon++;
			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if(selectedWeapon <= 0)
			{
				selectedWeapon = transform.childCount-1;
			}
			else
			{
				selectedWeapon--;
			}
		}

		if(previousSelectedWeapon != selectedWeapon)
		{
			selectWeapon();
		}
	}

	void selectWeapon()
	{
		int i = 0;
		foreach (Transform weapon in transform)
		{
			if(i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
				weaponName.text = weapon.gameObject.name;
				weaponsStatsPickUp = weapon.gameObject.GetComponent<WeaponsStatsPickUp>();
				
				attackRate = weaponsStatsPickUp.attackRate;
				damage = weaponsStatsPickUp.damage;
				range = weaponsStatsPickUp.range;
				melee = weaponsStatsPickUp.melee;
				hit = weaponsStatsPickUp.hit;
				ammo = weaponsStatsPickUp.ammo;
				clipSize = weaponsStatsPickUp.clipSize;
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
