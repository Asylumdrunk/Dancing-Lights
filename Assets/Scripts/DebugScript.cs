using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that disables all debug used gameobjects
//such as the giant mask that shows all of the level
public class DebugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
