using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase  {        

	static private List<Weapon> weaponList;
	static private List<Armor> armorList;
	static private List<Bullet> bulletList;

	static private bool isDatabaseLoaded = false;

	static private void ValidateDatabase(){
		if (weaponList == null)
			weaponList = new List<Weapon> ();
		if (armorList == null)
			armorList = new List<Armor> ();
		if (bulletList == null)
			bulletList = new List<Bullet> ();
		
		if (!isDatabaseLoaded)
			LoadDatabase ();
	}

	static public void LoadDatabase(){
		if (isDatabaseLoaded)
			return;
		isDatabaseLoaded = true;
		ForceLoadDatabase ();
	}

	static public void ForceLoadDatabase(){
		ValidateDatabase ();

		Weapon[] resources1 = Resources.LoadAll<Weapon> (@"Weapon");
		foreach (Weapon weapon in resources1) {
			Debug.Log ("ForceLoad Weapon");
			weaponList.Add (weapon);
		}

		Armor[] resources2 = Resources.LoadAll<Armor> (@"Armor");
		foreach (Armor armor in resources2) {
			Debug.Log ("ForceLoad Armor");
			armorList.Add (armor);
		}

		Bullet[] resources3 = Resources.LoadAll<Bullet> (@"Bullet");
		foreach (Bullet bullet in resources3) {
			Debug.Log ("ForceLoad Armor");
			bulletList.Add (bullet);
		}

	}
			
	static public void clear(){
		isDatabaseLoaded = false;
		weaponList.Clear ();
		armorList.Clear ();
		bulletList.Clear ();
	}

	static public Weapon GetWeaponByID(string id) {
		ValidateDatabase ();
		foreach (Weapon weapon in weaponList) {
			if (weapon.ID.ToLower ().Equals (id.ToLower ())) {
				return ScriptableObject.Instantiate (weapon) as Weapon;
			}
		}
		return null;
	}

	static public Armor GetArmorByID(string id) {
		ValidateDatabase ();
		foreach (Armor armor in armorList) {
			if (armor.ID.ToLower ().Equals (id.ToLower ())) {
				return ScriptableObject.Instantiate (armor) as Armor;
			}
		}
		return null;
	}

	static public Bullet GetBulletByID(string id) {
		ValidateDatabase ();
		foreach (Bullet bullet in bulletList) {
			if (bullet.ID.ToLower ().Equals (id.ToLower ())) {
				return ScriptableObject.Instantiate (bullet) as Bullet;
			}
		}
		return null;
	}
}
