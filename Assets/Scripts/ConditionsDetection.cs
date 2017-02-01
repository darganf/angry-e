using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionsDetection : MonoBehaviour {

	private Rigidbody2D rb;

	public Text middleLevelText;
	public Button nextLevelButton;

	private MovementAndRelated movementScript;
	private bool otherConMet;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		movementScript = GetComponent<MovementAndRelated> ();
		middleLevelText.text = " ";
		nextLevelButton.gameObject.SetActive (false);
		otherConMet = false;
	}

	void Update () {
		if (movementScript.initialClicked) {
			StartCoroutine (speedCheck());
		}
	}

	IEnumerator speedCheck() {
		yield return new WaitForSeconds (1);
		if (rb.velocity.magnitude < .1 && !otherConMet) {
			rb.velocity = Vector2.zero;
			middleLevelText.text = "Hurricane Cannot Travel Any Further!";
		}
	}

	/* Displays text depending on the tag of the game object that the hurricane collides with. */
	void OnTriggerEnter2D(Collider2D other) {
		if (!other.CompareTag ("Untagged")) {
			rb.velocity = Vector2.zero;
			if (other.CompareTag ("Building")) {
				middleLevelText.text = "Area Successfully Hit!";
				nextLevelButton.gameObject.SetActive (true);
			} else if (other.CompareTag ("Equator")) {
				middleLevelText.text = "Hurricanes Cannot Pass the Equator!";
			}
			otherConMet = true;
		}
	}
}
