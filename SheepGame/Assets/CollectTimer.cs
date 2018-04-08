using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTimer : MonoBehaviour {

	bool activated;
	float timeLeft;
	public bool victory;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		victory = false;
		textObject = GameObject.Find ("CollectTimer").GetComponent<TextMesh> ();
		textObject.text = "Timer: 10";
		timeLeft = 10;
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
		Destroy(GameObject.FindGameObjectWithTag ("Collect"));
		if (!victory) {
			TextMesh mazeText = GameObject.Find ("CollectEnd").GetComponent<TextMesh> ();
			mazeText.text = "Failure";
		}
	}

	public void activate() {
		activated = true;
	}
}