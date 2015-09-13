using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

	Player player = new Player();

	void Start () {
		player.createExperienceCurve ();
	}

	void Update () {

	}

}