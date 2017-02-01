using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	/* Resets the level to its starting state. */
	public void ResetLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	/* Loads the "level select" screen. */
	public void LevelSelect () {
		SceneManager.LoadScene ("Level Select");
	}

	/* Loads the first level. */
	public void LoadLevel1 () {
		SceneManager.LoadScene ("Level 1");
	}

	/* Loads the next level based on the index number in the build. */
	public void NextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
