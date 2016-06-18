using UnityEngine;
using UnityEditor;
using System.Collections;

public class Util {
	[MenuItem("Assets/Create/Item/Weapon")]
	static public void CreateWeapon(){
		ScriptableObjectUtil.CreateAsset<Weapon> ();
	}

	[MenuItem("Assets/Create/Item/Armor")]
	static public void CreateArmor(){
		ScriptableObjectUtil.CreateAsset<Armor> ();
	}

	[MenuItem("Assets/Create/Item/Bullet")]
	static public void CreateBullet(){
		ScriptableObjectUtil.CreateAsset<Bullet> ();
	}

}