using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Camera main;
	public Camera follow;
	public Canvas canvasMain;

	void Start () {
		follow.enabled = false;
	}
	
	public void SwitchCamera () {
		if (main.gameObject.activeSelf) {
			main.gameObject.SetActive (false);
			follow.enabled = true;
			follow.gameObject.SetActive (true);
			canvasMain.worldCamera = follow;
		} else {
			main.gameObject.SetActive (true);
			follow.enabled = false;
			canvasMain.worldCamera = main;
		}
	}
}
