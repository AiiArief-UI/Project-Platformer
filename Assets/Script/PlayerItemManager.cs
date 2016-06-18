using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerItemManager : MonoBehaviour {


	// Use this for initialization
	public int initSize;

	private List<string> listofArmorID = new List<string>();
	private List<string> listofWeaponID = new List<string>();

	private int equipedWeapon;
	private int equipedArmor;
	public int ammo;

	private GameObject player;

	void Start () {
		/*
		if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");
		*/
		player = GameObject.FindWithTag ("player");
		equipedArmor 	= 0;
		equipedWeapon 	= 0;

	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool weaponIsFull(){
		return listofWeaponID.Count >= initSize;
	}

	public bool armorIsFull(){
		return listofArmorID.Count >= initSize;
	}

	public void putWeapon(Weapon weapon){
		listofWeaponID.Add (weapon.ID);
	}

	public void putArmor(Armor armor){
		listofArmorID.Add (armor.ID);
	}

	bool containsArmor(string id){
		return listofArmorID.Contains (id);
	}

	bool containsWeapon(string id){
		return listofWeaponID.Contains (id) ;
	}
}
