using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWorld : MonoBehaviour {

	public Transform terrainSet1;
	public Transform terrainSet2;

	public GameObject mainCamera;
	CameraController sceneCamera;

	Vector2 newTerrainXPos;

	bool isWhite;

	//initialize the color of all terrain (left is white, right is black)
	void Start () {
		sceneCamera = mainCamera.GetComponent<CameraController> ();

		isWhite = true;
		int numChildren1 = terrainSet1.childCount;
		int numChildren2 = terrainSet2.childCount;

		for (int i = 0; i < numChildren1; i++) {
			terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (1,1,1);
			terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
			terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
		}

		for (int i = 0; i < numChildren2; i++) {
			terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (0,0,0);
			terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
			terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
		}
	}

	void Update () {
		//cannot move while camera is transitioning
		if (!sceneCamera.animatingCamera) {
			if (Input.GetKeyDown (KeyCode.Space)) {

				//number of children in the terrain sets
				int numChildren1 = terrainSet1.childCount;
				int numChildren2 = terrainSet2.childCount;

				//for every piece of terrain in set 1, multiply the x position by -1 to move it to the other side and color it the opposite color
				for (int i = 0; i < numChildren1; i++) {
					newTerrainXPos = new Vector2 (-terrainSet1.GetChild (i).position.x, terrainSet1.GetChild (i).position.y);
					terrainSet1.GetChild (i).position = newTerrainXPos;

					if (isWhite) {
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
					} else {
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (1, 1, 1);
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
						terrainSet1.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
					}
				}

				//for every piece of terrain in set 2, multiply the x position by -1 to move it to the other side and color it the opposite color
				for (int i = 0; i < numChildren2; i++) {
					newTerrainXPos = new Vector2 (-terrainSet2.GetChild (i).position.x, terrainSet2.GetChild (i).position.y);
					terrainSet2.GetChild (i).position = newTerrainXPos;

					if (isWhite) {
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (1, 1, 1);
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
					} else {
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
						terrainSet2.GetChild (i).gameObject.GetComponent<Renderer> ().material.SetFloat ("_SpecularHighlights", 0);
					}
				}

				//controlls the color of both sides
				isWhite = !isWhite;
			}
		}
	}
}
