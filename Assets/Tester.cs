using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {


	// Use this for initialization
	void Start () {

		Weapon item = ItemDatabase.GetWeaponByID ("1");
		if (item != null) {
			Debug.Log ("item ID : " + item.ID + "-item Name : " + item.name + "-itemType : " + item.isRanged + "-itemDamage : " + item.damage);
		} else {
			Debug.Log ("NULL");
		}

		item = ItemDatabase.GetWeaponByID ("0");
		if (item != null) {
			Debug.Log ("item ID : " + item.ID + "-item Name : " + item.name + "-itemType : " + item.isRanged + "-itemDamage : " + item.damage);
		} else {
			Debug.Log ("NULL");
		}

		Armor armor = ItemDatabase.GetArmorByID ("1");
		if (armor != null) {
			Debug.Log("item ID : " + armor.ID + "-item Name : " + armor.name + "-itemDeff : " + armor.deff);
		} else {
			Debug.Log ("NULL");
		}

		armor = ItemDatabase.GetArmorByID ("0");
		if (armor != null) {
			Debug.Log("item ID : " + armor.ID + "-item Name : " + armor.name + "-itemDeff : " + armor.deff);
		} else {
			Debug.Log ("NULL");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
