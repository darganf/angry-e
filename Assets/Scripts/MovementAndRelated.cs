using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementAndRelated : MonoBehaviour {

	public Camera main;
	public Camera follow;

	public Slider tempBar; // Temperature bar slider.

	public float con; // limit for the line renderer's length.
	public float speed; // How fast the game object should go.

	private Rigidbody2D rb; // Rigidbody of the game object.

	private LineRenderer pointer; // Pointer when aiming.

	private Vector2 objectPos; // Position of the game object.
	private Vector2 mousePos; // Mouse position on the screen.

	public bool initialClicked; // Has the game object been clicked?
	public bool holdMouseDown; // Is the mouse being held down?

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
		//*rb.AddTorque (-500);
		pointer = rb.GetComponent<LineRenderer> ();
        initialClicked = false;
		holdMouseDown = false;
    }

	/* Adjusts the temperature bar and aimer when needed. */
	void Update ()
	{
		if (!initialClicked && holdMouseDown) {
			Vector2 direction = directionCheck ();
			tempBar.value = (direction * speed / (con * speed)).magnitude;
			pointer.SetPosition (1, objectPos + direction);
		} else {
			tempBar.value = rb.velocity.magnitude / 10; // 10 is the max velocity from testing
		}
	}

	/* Have the pointer appear when the game object is clicked and held down
	 * for the first time. */
	void OnMouseDown ()
	{
		if (!initialClicked) {
			objectPos = rb.position;
			pointer.sortingOrder = 6;
			// pointer.material = new Material (Shader.Find("Particles/Additive"));
			// pointer.startColor = Color.black;
			// pointer.endColor = Color.red;
			pointer.material.color = Color.grey;
			pointer.sortingOrder = 6;
			pointer.startWidth = 0.15f;
			pointer.endWidth = 0.3f;
			pointer.numPositions = 2;
			pointer.SetPosition (0, objectPos);
			holdMouseDown = true;
		}
	}

	/* Adds force in the opposite direction of the mouse pointer
	 * and adjusting for the wanted speed and removes the pointer. */
	void OnMouseUp ()
	{
		if (!initialClicked) {
			Vector2 direction = directionCheck ();
			rb.AddForce (direction * speed);
			initialClicked = true;
			holdMouseDown = false;
			Destroy (pointer);
		}
	}

	/* Gets the direction opposite of where the mouse is to the object 
	 * limited to a radius constraint 'con'. */
	Vector2 directionCheck ()
	{
		if (main.isActiveAndEnabled) {
			mousePos = main.ScreenToWorldPoint (Input.mousePosition);
		} else {
			mousePos = follow.ScreenToWorldPoint (Input.mousePosition);
		}
		Vector2 direction = objectPos - mousePos;
		float radius = Vector2.Distance(objectPos, mousePos);
		if (radius > con) {
			float scale = radius / con;
			direction.x = direction.x  / scale;
			direction.y = direction.y  / scale;
		}
		return direction;
	}
}
