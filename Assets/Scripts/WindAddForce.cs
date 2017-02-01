using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAddForce : MonoBehaviour {

//	public GameObject hurricane; // The primary game object of the hurricane.
	public float windAmount; // How much the wind would change the direction per frame.

//	private Rigidbody2D rbHurricane; // The rigid body of the hurricane game object.
	private Vector2 windDirection; // The direction where the wind is pointing.

	void Start () {
//		rbHurricane = hurricane.GetComponent<Rigidbody2D> ();
		windDirection = new Vector2 (transform.up.x, transform.up.y).normalized;
	}

	/* Changes the direction of the hurricane in incrementals per frame based on the
	 * direction of the wind game object. */
	void OnTriggerStay2D (Collider2D other) {
		float currentVelo = other.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
		Vector2 direction = other.gameObject.GetComponent<Rigidbody2D> ().velocity.normalized;
		if (direction.x < windDirection.x) {
			direction.x += windAmount;
		} else {
			direction.x -= windAmount;
		}
		if (direction.y < windDirection.y) {
			direction.y += windAmount;
		} else {
			direction.y -= windAmount;
		}
		other.gameObject.GetComponent<Rigidbody2D> ().velocity = currentVelo * direction;
	}
}
