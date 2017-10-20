using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;

	public GameObject mainCamera;
	CameraController sceneCamera;

	public GameObject otherPlayer;
	PlayerController otherController;

	public Transform groundCheck;
	[HideInInspector] public bool grounded;
	[HideInInspector] public bool jump = false;

	public float moveSpeed = 8f;
	public float posDirection;
	public float jumpForce = 17f;

	//Initialize variables on start
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		sceneCamera = mainCamera.GetComponent<CameraController> ();
		otherController = otherPlayer.GetComponent<PlayerController> ();
		rb2d.freezeRotation = true;
	}

	void Update () {
		//if the camera is not in tranistion
		if (!sceneCamera.animatingCamera) {
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

			//When user hits the jump button, checks that both players are grounded so that they can jump
			//if both user are grounded, set the jump to true (set other controllers jump to true as well to fix a de-sync bug)
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				if (grounded && otherController.grounded) {
					jump = true;
					otherController.jump = true;
				}
			}
		}
	}

	void FixedUpdate () {
		//if the camera is not in transition
		if (!sceneCamera.animatingCamera) {
			//change player velocity
			//if they press right key, white will move right and black will move left
			//vice versa for the left key
			float moveHorizontal = Input.GetAxis ("Horizontal");
			rb2d.velocity = new Vector2 (moveHorizontal * moveSpeed * posDirection, rb2d.velocity.y);

			//if the player jumps apply a velocity to both players
			if (jump) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
				jump = false;
			}
		}
	}
}
