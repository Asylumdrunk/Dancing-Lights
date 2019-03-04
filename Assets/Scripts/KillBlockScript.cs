using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBlockScript : MonoBehaviour {
	private GameObject player;
	private Animator myAnimator;
	private GameObject deathAnimation;
	private ParticleSystem particleSystem;
	private AudioSource soundEffect;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		myAnimator = player.GetComponent<Animator>();
		deathAnimation = GameObject.FindGameObjectWithTag ("Death");
		particleSystem = deathAnimation.GetComponent<ParticleSystem> ();
		soundEffect = gameObject.GetComponent<AudioSource> ();
	}

	void Update() {

	}

	void OnTriggerEnter2D (Collider2D col) {
		GlobalVariables.gameState = false;
		deathAnimation.transform.position = col.attachedRigidbody.transform.position;
		particleSystem.Simulate (0.0f, true, true);
		particleSystem.Play ();
		col.attachedRigidbody.transform.position = GlobalVariables.playerStartLocation;
		col.attachedRigidbody.velocity = new Vector2(0, 0);
		myAnimator.SetFloat("speed", 0);
		myAnimator.SetBool ("land", true);
		soundEffect.Play ();
	}
}
