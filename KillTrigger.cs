using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTrigger : MonoBehaviour {

	public string currentLevel;

	//if the player dies, reset the level
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			//NextLevel.firstTimeInLevel = false;
			NextLevel.firstTimeInLevel = false;
			SceneManager.LoadScene (currentLevel);
		}
	}
}
