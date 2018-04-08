using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonStuff : MonoBehaviour {

	public int score;
	string btnName;
	public CarrotTimer carrotScript;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began) {
			Debug.Log ("touch");
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit Hit;
			if(Physics.Raycast(ray, out Hit)) {
				btnName = Hit.transform.name;
				switch(btnName)
				{
				case "Carrot":
					score++;
					Destroy (Hit.transform.gameObject);
					Debug.Log ("ok");
					break;
				}
			}
		}

		if (score >= 25) {
			Destroy (GameObject.FindGameObjectWithTag ("Carrot"));
			TextMesh mazeText = GameObject.Find ("CarrotEnd").GetComponent<TextMesh> ();
			mazeText.text = "You get a point!!";
			carrotScript.victory = true;
		}
	}
}
