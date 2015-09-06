using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

	public enum Effect{
		Health,
		Poison
	};

	//public Effect potionEffect;
	public float EffectDuration;
	public float Health = 0;
	public bool CanAddExtraHealth = false;
	public float Energy = 0;
	public bool CanAddExtraEnergy = false;
	public float MovementVelocity = 0;
	public float AttackDamage = 0;
	public float AttackSpeed = 0;
	public float AttackDefense = 0;
	public float MagicAttack = 0;
	public float MagicDefense = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
