using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCount : MonoBehaviour {


	public CropTimer2 cropScript;
	bool victory;
	bool over;
	string btnName;

	// Use this for initialization
	void Start () {
		victory = false;
		over = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began && cropScript.timeLeft <= 0) {
			Debug.Log ("touch");
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit Hit;
			if(Physics.Raycast(ray, out Hit)) {
				btnName = Hit.transform.name;
				switch(btnName)
				{
				case "onionbut":
					over = true;
					Debug.Log ("four");
					Destroy (Hit.transform.gameObject);
					victory = false;
					break;
				case "tomatobut":
					over = true;
					Destroy (Hit.transform.gameObject);
					victory = true;
					break;
				case "pizzabut":
					over = true;
					Destroy (Hit.transform.gameObject);
					victory = false;
					break;
				}
			}
		}

		if (over) {
			Destroy(GameObject.FindGameObjectWithTag ("button"));
			TextMesh cropText = GameObject.Find ("CropEnd").GetComponent<TextMesh> ();
			if (victory) {
				cropText.text = "Move to next green";
			} else {
				cropText.text = "Failure";
			}
		}
	}
}
