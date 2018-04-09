using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotTimer : MonoBehaviour {

	bool activated;
	float timeLeft;
	public bool victory;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		victory = false;
		textObject = GameObject.Find ("CarrotTimer").GetComponent<TextMesh> ();
		textObject.text = "Timer: 20";
		timeLeft = 20;
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
		Destroy(GameObject.FindGameObjectWithTag ("Carrot"));
		if (!victory) {
			TextMesh carrotText = GameObject.Find ("CarrotEnd").GetComponent<TextMesh> ();
			carrotText.text = "Failure";
		}
	}

	public void activate() {
		activated = true;
	}
}
