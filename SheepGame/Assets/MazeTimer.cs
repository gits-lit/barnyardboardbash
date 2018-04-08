using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTimer : MonoBehaviour {

	bool activated;
	float timeLeft;
	public bool victory;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		victory = false;
		textObject = GameObject.Find ("MazeTimer").GetComponent<TextMesh> ();
		textObject.text = "Timer: 30";
		timeLeft = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			timeLeft -= Time.deltaTime;
			textObject.text = "Timer: " + timeLeft;
			if (timeLeft < 0) {
				GameOver ();
			}
		}
	}

	void GameOver() {
		Destroy(GameObject.FindGameObjectWithTag ("Maze"));
		if (!victory) {
			TextMesh mazeText = GameObject.Find ("MazeEnd").GetComponent<TextMesh> ();
			mazeText.text = "Failure";
		}
	}

	public void activate() {
		activated = true;
	}
}
