using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTimer2 : MonoBehaviour {

	bool activated;
	public float timeLeft;
	TextMesh textObject;

	// Use this for initialization
	void Start () {
		textObject = GameObject.Find ("cropTimer").GetComponent<TextMesh> ();
		textObject.text = "Timer: 5";
		timeLeft = 5;
		GameObject.Find ("tomatobut").transform.Translate (Vector3.up * 5000);
		GameObject.Find("onionbut").transform.Translate(Vector3.up*5000);
		GameObject.Find ("pizzabut").transform.Translate (Vector3.up*5000);
	}

	// Update is called once per frame
	void Update () {
		if (activated) {
			timeLeft -= Time.deltaTime;
			textObject.text = "Timer: " + timeLeft;
			if (timeLeft <= 0) {
				question ();
			}
		}
	}

	void question() {
		Destroy(GameObject.FindGameObjectWithTag ("Crops"));
		GameObject.Find ("tomatobut").transform.Translate (Vector3.down * 5000);
		GameObject.Find("onionbut").transform.Translate(Vector3.down*5000);
		GameObject.Find ("pizzabut").transform.Translate (Vector3.down*5000);
		TextMesh mazeText = GameObject.Find ("CropQuestion").GetComponent<TextMesh> ();
		mazeText.text = "Which object appears the most?";
	}

	public void activate() {
		activated = true;
	}
}
