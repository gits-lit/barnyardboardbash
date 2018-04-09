using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullTimer : MonoBehaviour {

	bool activated;
	float timeLeft;
	public bool victory;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		victory = true;
		textObject = GameObject.Find ("BullTimer").GetComponent<TextMesh> ();
		textObject.text = "Timer: 10";
		timeLeft = 10;
	}

	// Update is called once per frame
	void Update () {
		if (activated) {
			timeLeft -= Time.deltaTime;
			textObject.text = "Timer: " + timeLeft;
			if (timeLeft < 0) {
				Victory ();
			}
		}
	}

	void Victory() {
		Destroy(GameObject.FindGameObjectWithTag ("bull"));
		if (victory) {
			TextMesh mazeText = GameObject.Find ("BullEnd").GetComponent<TextMesh> ();
			mazeText.text = "Move to next brown";
		}
	}

	public void activate() {
		activated = true;
	}
}
