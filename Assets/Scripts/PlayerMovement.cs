using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	bool isAnimating = false;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mVector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(mVector.x != 0 && !isAnimating) {
			anim.SetBool ("is_walking", true);
			anim.SetFloat("input_x", mVector.x);
			isAnimating = true;
		} else {
			isAnimating = false;
		}

		if(mVector.y != 0 && !isAnimating) {
			anim.SetBool ("is_walking", true);
			anim.SetFloat("input_y", mVector.y);
			isAnimating = true;
		} else {
			isAnimating = false;
		}

		if(mVector == Vector2.zero) {
			anim.SetBool ("is_walking", false);
		}

		rbody.MovePosition (rbody.position + mVector * Time.deltaTime);
	}
}
