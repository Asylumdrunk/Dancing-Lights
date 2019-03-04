using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
	private bool placed = false;
	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		if (gameObject.name == "baseLightObject") {
			placed = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!placed) {
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			mousePos.z = 10;
			gameObject.transform.position = mousePos;
		}
		if (Input.GetMouseButtonDown(0)) {
			placed = true;
			UIScript.instructionsStep = true;
		}
	}
}
