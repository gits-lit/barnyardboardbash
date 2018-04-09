using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTimer : MonoBehaviour {

	bool activated;
	float timeLeft;
	public bool victory;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		victory = false;
		textObject = GameObject.Find ("DuckTimer").GetComponent<TextMesh> ();
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

	public void GameOver() {
		Destroy(GameObject.Find ("DuckGame"));
		if (!victory) {
			TextMesh duckText = GameObject.Find ("DuckEnd").GetComponent<TextMesh> ();
			duckText.text = "Failure";
		}
	}

	public void activate() {
		activated = true;
	}
}

