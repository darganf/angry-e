using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmSpeedAdjust : MonoBehaviour {

	public float speedIncrement; // How fast the water object will increase the speed per frame.

	private float prevDrag; // Holds how much drag was affecting the hurricane game object.

	void Start () {
		prevDrag = 0f;
	}

	/* Changes the drag to the game object to zero when entering the water object. */
	void OnTriggerEnter2D (Collider2D other) {
		prevDrag = other.gameObject.GetComponent<Rigidbody2D> ().drag;
		other.gameObject.GetComponent<Rigidbody2D> ().drag = 0;
	}

	/* Increases the velocity per frame */
	void OnTriggerStay2D (Collider2D other) {
		Vector2 direction = other.gameObject.GetComponent<Rigidbody2D> ().velocity.normalized;
		float currentVelo = other.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
		float newVelo = currentVelo + speedIncrement;
		if (newVelo > 10) {
			newVelo = 10;
		}
		other.gameObject.GetComponent<Rigidbody2D> ().velocity = direction * newVelo;
	}

	/* Re-adds the drag to the hurricane object when leaving the water object. */
	void OnTriggerExit2D (Collider2D other) {
		other.gameObject.GetComponent<Rigidbody2D> ().drag = prevDrag;
	}
}
