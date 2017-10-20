using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public GameObject whitePlayer;
	public GameObject blackPlayer;

	public GameObject mainCamera;
	CameraController sceneCamera;

	bool animTrigger;
	[HideInInspector] public static bool firstTimeInLevel;

	public string nextLevel;
	public string currentLevel;
	float threshold = 1.2f;

	void Start () {
		sceneCamera = mainCamera.GetComponent<CameraController> ();
		animTrigger = true;
	}

	void Update () {
		//calculate the distance between the players
		float distance = Vector2.Distance (whitePlayer.transform.position, blackPlayer.transform.position);

		//if the distance is less than the threshold, trigger animation
		if (distance < threshold && animTrigger) {
			sceneCamera.startAnimation = false;
			sceneCamera.animatingCamera = true;
			animTrigger = false;
		}

		//if the scene is done with the exit animation go to the next level
		if (!sceneCamera.animatingCamera && !animTrigger) {
			if (!sceneCamera.animatingCamera) {
				firstTimeInLevel = true;
				SceneManager.LoadScene (nextLevel);
			}
		}

		//R resets the current level
		if (!sceneCamera.animatingCamera && Input.GetKeyDown (KeyCode.R)) {
			firstTimeInLevel = false;
			SceneManager.LoadScene (currentLevel);
		}
	}
}
