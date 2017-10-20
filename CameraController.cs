using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public Transform whitePlayer;
	//public Transform blackPlayer;

	[HideInInspector] public bool animatingCamera;
	[HideInInspector] public bool startAnimation;
	float cameraPos;
	float moveScale;

	void Start () {
		if (NextLevel.firstTimeInLevel) {
			transform.position = new Vector3 (-50, 0, -10);
			animatingCamera = true;
			startAnimation = true;
		} else {
			transform.position = new Vector3 (0, 0, -10);
			animatingCamera = false;
		}
		moveScale = 0.5f;
	}

	// Update is called once per frame
	void Update () {

		if (animatingCamera && startAnimation) {
			cameraPos = transform.position.x;
			if (cameraPos < 0) {
				cameraPos += moveScale;
				transform.position = new Vector3 (cameraPos, 0, -10);
			} else {
				animatingCamera = false;
				transform.position = new Vector3 (0, 0, -10);
			}
		} else if (animatingCamera && !startAnimation) {
			cameraPos = transform.position.x;
			if (cameraPos < 50) {
				cameraPos += moveScale;
				transform.position = new Vector3 (cameraPos, 0, -10);
			} else {
				animatingCamera = false;
			}
		}
	}
}
