using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laucherScript : MonoBehaviour {

	[SerializeField]
	private int upwardForce;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		col.attachedRigidbody.velocity = Vector2.zero;
		col.attachedRigidbody.angularVelocity = 0;
		col.attachedRigidbody.AddForce (new Vector2 (0, upwardForce));
		sound.Play ();
	}
}
