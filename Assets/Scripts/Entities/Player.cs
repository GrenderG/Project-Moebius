using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Entity {

	private float experiencePoints;
	private readonly long xpForFirstLevel = 1000;
	private readonly long xpForLastLevel = 1000000;
	private readonly long[] xpCurve;

	public Player () {
		this.xpCurve = new long[base.maxLevel + 1];
	}

	public Player (float healthPoints, float manaPoints, int level, Dictionary<string, float> resistances, Dictionary<string, float> damages, Dictionary<string, int> stats,
	               float attackSpeed, float movementSpeed, float criticalChance, float criticalDamagePercentage, float experiencePoints) :
		base(healthPoints, manaPoints, level, resistances, damages, stats, attackSpeed, movementSpeed, criticalChance, criticalDamagePercentage) {

		this.xpCurve = this.createExperienceCurve ();
		this.experiencePoints = experiencePoints;

	}

	public long[] createExperienceCurve () {

		long[] xpCurve = new long[base.maxLevel];

		for (int i = 1; i <= base.maxLevel; i++)
		{
			xpCurve[i] = (long) (i * (Mathf.Pow (i, 3)) / 5);
			Debug.Log(xpCurve[i]);
		}

		return xpCurve;
	}

}