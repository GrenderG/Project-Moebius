using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity {
	
	private float healthPoints;
	private float manaPoints;
	private int level;
	protected readonly int maxLevel = 40;
	private Dictionary<string, float> resistances = new Dictionary<string, float>();
	private Dictionary<string, float> damages = new Dictionary<string, float>();
	private Dictionary<string, int> stats = new Dictionary<string, int>();
	private float attackSpeed;
	private float movementSpeed;
	private float criticalChance;
	private float criticalDamagePercentage;

	public Entity () {

	}

	public Entity (float healthPoints, float manaPoints, int level, Dictionary<string, float> resistances, Dictionary<string, float> damages, Dictionary<string, int> stats,
	               float attackSpeed, float movementSpeed, float criticalChance, float criticalDamagePercentage) {
		this.healthPoints = healthPoints;
		this.manaPoints = manaPoints;
		this.level = level;
		this.resistances = resistances;
		this.damages = damages;
		this.stats = stats;
		this.attackSpeed = attackSpeed;
		this.movementSpeed = movementSpeed;
		this.criticalChance = criticalChance;
		this.criticalDamagePercentage = criticalDamagePercentage;
	}

	public float HealthPoints {
		get { return this.healthPoints; }
		set { this.healthPoints = value; } 
	}

	public float ManaPoints {
		get { return this.manaPoints; }
		set { this.manaPoints = value; } 
	}

	public int Level {
		get { return this.level; }
		set { 
			this.level = (value > this.maxLevel ? this.maxLevel : value);
		} 
	}

	public Dictionary<string, float> Resistances {
		get { return this.resistances; }
		set { this.resistances = value; } 
	}

	public Dictionary<string, float> Damage {
		get { return this.damages; }
		set { this.damages = value; } 
	}

	public Dictionary<string, int> Stats {
		get { return this.stats; }
		set { this.stats = value; } 
	}

	public float AttackSpeed {
		get { return this.attackSpeed; }
		set { this.attackSpeed = value; } 
	}

	public float MovementSpeed {
		get { return this.movementSpeed; }
		set { this.movementSpeed = value; } 
	}

	public float CriticalDamagePercentage {
		get { return this.criticalDamagePercentage; }
		set { this.criticalDamagePercentage = value; } 
	}

	public float CriticalChance {
		get { return this.criticalChance; }
		set { this.criticalChance = value; } 
	}

}