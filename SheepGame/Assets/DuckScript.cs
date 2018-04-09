using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour {
	int score;
	public Transform spawnPoint;
	public GameObject chickPrefab;
	public DuckTimer duckTimerScript;
	public GameObject game;
	public GameObject targ;
	public int chickCount = 0;

	void Start() {
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Chick") {
			Destroy (col.gameObject);
			score++;
			AddChick ();

		} else if (col.gameObject.name == "ChickFollower") {
			duckTimerScript.GameOver ();
		}
	}

	void AddChick() {
		if (chickCount == 0) {
			targ = GameObject.Find("/DuckGame/DuckMom/Offset").gameObject;
		} else {
			targ = GameObject.Find("/DuckGame/chick" + chickCount).gameObject;
		}

		GameObject newchick = Instantiate (chickPrefab, targ.transform.position, targ.transform.rotation);
		newchick.name = "chick" + chickCount;
		newchick.transform.localScale += new Vector3(0.4F, 0.4F, 0.4F);
		newchick.transform.SetParent (game.transform);
		newchick.GetComponent<ChickScript> ().setTarg (targ);
		chickCount++;
	}
}
