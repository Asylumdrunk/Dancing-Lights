using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

	public static bool gameState;
	public static int lightCounter;
	public static Vector2 playerStartLocation;
	private bool created;

	// Use this for initialization
	void Start () {
		if (!created) {
			DontDestroyOnLoad (gameObject);
			created = true;
			gameState = false;
			lightCounter = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
