using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour {

	public GameObject hurricane; // The game object that the camera will follow.

	private Vector3 offset;

	void Start () {
		offset = transform.position - hurricane.transform.position;
	}
	
	void LateUpdate () {
		transform.position = hurricane.transform.position + offset;
	}
}
