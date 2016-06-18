using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {


	public string insideID;
	public int distanceToOpenStorage;
	public int itemType;
	/**
	example :
	1 = weapon
	2 = armor
	3 = bullet only
	*/

	private  Weapon weaponInside;
	private Armor armorInside;
	private Bullet bulletInside;

	private GameObject player;
	private PlayerItemManager itemManager;
	private bool isEmpty;


	// Use this for initialization
	void Start () {
		isEmpty = true;
		if (itemType == 1 && weaponInside == null) {
			weaponInside = ItemDatabase.GetWeaponByID (insideID);
			isEmpty = false;
		}
		else if (itemType == 2 && armorInside == null) {
			armorInside = ItemDatabase.GetArmorByID (insideID);
			isEmpty = false;
		}
		else if (itemType == 3 && weaponInside == null) {
			bulletInside = ItemDatabase.GetBulletByID (insideID);
			isEmpty = false;
		}

		player = GameObject.FindWithTag ("Player");
		itemManager = player.GetComponent<PlayerItemManager>();
	}
	
	// Update is called once per frame
	void Update () {
		

		float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);


		if (distance <= distanceToOpenStorage && Input.GetKeyDown ("E") && !isEmpty) {
			//TODO : open chest and check player
			if (itemType == 1) {
				if (itemManager.weaponIsFull ()) {
					Debug.Log ("weapon is full");
				} else {
					itemManager.putWeapon (weaponInside);
				}
			} 
			if (itemType == 2) {
				if (itemManager.armorIsFull ()) {
					Debug.Log ("armor full");
				} else {
					itemManager.putArmor (armorInside);
				}
			} else {
				itemManager.ammo += bulletInside.ammount;
			}
		}
	}
}