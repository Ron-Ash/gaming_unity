using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatsPickUp : MonoBehaviour {

	public float attackRate;
	public float damage;
	public float range;
	public bool melee;
	bool weaponInventory;
	public Renderer weaponRenderer;
	public GameObject player;
	public LayerMask hit;
	public float ammo;
	public float clipSize;

	

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag("WeaponsCase");
		transform.localScale = new Vector3(0.3f, 0.3f, 1);
		weaponInventory = false;
		weaponRenderer.enabled = true;
	}

	//void FixedUpdate()
	//{
		
		//if(Input.GetButtonDown("PickUp") && weaponInventory == true)
		//{
			//this.gameObject.transform.position = player.transform.position;
			//Debug.Log("Player dropped "+ name);
			//weaponInventory = !weaponInventory;
			//weaponRenderer.enabled = true;
			//this.gameObject.transform.parent = null;
			//Debug.Log(weaponInventory);
		//}
	//}
		
	void OnTriggerStay2D(Collider2D coll)
	{
		Debug.Log("collision");
		if(Input.GetButtonDown("PickUp") && coll.gameObject.tag == "Player" && weaponInventory == false)
		{
			Debug.Log("Player picked up "+ name);
			weaponInventory = !weaponInventory;
			weaponRenderer.enabled = false;
			this.gameObject.transform.parent = player.transform;
			Debug.Log(weaponInventory);
		}
	}
}
