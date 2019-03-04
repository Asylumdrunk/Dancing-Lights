using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
	//creates the gameobject in order to access the gamestate
	// Use this for initialization
	[SerializeField]
	public CanvasGroup canvasGroup;
	private GameObject baseLight;
	private GameObject newLight;
	private Vector3 mousePos;
	public static bool instructionsStep = false;
	private Text textBox;

	void Start () {
		if (gameObject.tag == "Button") {
			GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (() => buttonPress ());
			baseLight = GameObject.FindGameObjectWithTag ("Light");
		} else if (gameObject.tag == "Text") {
			textBox = gameObject.GetComponent<UnityEngine.UI.Text>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (GlobalVariables.gameState) {
			canvasGroup.alpha = 0f;
			canvasGroup.blocksRaycasts = false;
		} else {
			canvasGroup.alpha = 1f;
			canvasGroup.blocksRaycasts = true;
		}
		if (gameObject.name == "endScreenText") {
			textBox.text = "Congratulations! You have completed this small project while only using " 
				+ GlobalVariables.lightCounter + " torches!";
		}
		if (instructionsStep && gameObject.tag == "Text" && gameObject.name == "Instructions") {
			textBox.text = "Okay, that should allow you to see a bit of your situation. You can move it around to see more, " +
				"but you'll need to place it down before you start moving around. Do this by clicking the left mouse button again." +
				"Place as many down as you need, and then" +
				"click the button in the top right to start moving around. The light in the bottom right is where you" +
				"should be heading to. It'll move you closer to us.";
			instructionsStep = false;
		}
	}
	void buttonPress() {
		if (gameObject.name == "makeLightButton") {
			mousePos = Input.mousePosition;
			mousePos.z = 10;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			newLight = Instantiate (baseLight, mousePos, Quaternion.identity) as GameObject;
			GlobalVariables.lightCounter++;
			changeInstructionText ();
		} else if (gameObject.name == "changeGameState") {
			GlobalVariables.gameState = true;
		} else if (gameObject.name == "exitButton") {
			Application.Quit ();
			Debug.Log ("quit");
		} else if (gameObject.name == "resetButton") {
			SceneManager.LoadScene (0, LoadSceneMode.Single);
		} else if (gameObject.name == "level1Button") {
			SceneManager.LoadScene (2, LoadSceneMode.Single);
		} else if (gameObject.name == "tutorialButton") {
			SceneManager.LoadScene (1, LoadSceneMode.Single);
		} else {
			Debug.Log ("This button name has no corresponding code");
		}
	}
	void changeInstructionText() {
		instructionsStep = true;
	}
}

