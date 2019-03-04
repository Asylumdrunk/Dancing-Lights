using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransitioner : MonoBehaviour {
	private int currentBuildIndex;
	void OnTriggerEnter2D(Collider2D col) {
		currentBuildIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentBuildIndex + 1, LoadSceneMode.Single);
		GlobalVariables.gameState = false;
	}
}
