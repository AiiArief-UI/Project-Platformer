using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Weapon : ScriptableObject
{
	public string name;
	public string ID;
	public bool isRanged;
	public int attackSpeed;
	public int damage;
}
