using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystems : MonoBehaviour {
	private float cameraStart;
	private GameObject player;
	private Vector3 mousePos;
	private bool reset = false;
	
	// Use this for initialization
	void Start () {
		//creates the game object again
		player = GameObject.FindWithTag("Player");
		//sets the camera's starting position. will not move left past this point
		cameraStart = transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		//checks if the player is less than or equal to the camera's starting position
		if (player.transform.position.x >= cameraStart && transform.position.x < 29.3) {
			transform.localPosition = new Vector3 (player.transform.position.x, 0, -10);
		}
		if (!GlobalVariables.gameState) {
			mousePos = Input.mousePosition;
			if (mousePos.x > Screen.width * 0.9 && transform.position.x < 29.3 && mousePos.y < Screen.height * 0.93) {
				transform.localPosition = new Vector3 (transform.position.x + 0.25f, 0, -10);
			} else if (mousePos.x < Screen.width * 0.1 && transform.position.x > cameraStart && mousePos.y < Screen.height * 0.93) {
				transform.localPosition = new Vector3 (transform.position.x - 0.25f, 0, -10);
			}
		}
		if (GlobalVariables.gameState && !reset) {
			transform.localPosition = new Vector3 (cameraStart, 0, -10);
			reset = true;
		}
	}
}
