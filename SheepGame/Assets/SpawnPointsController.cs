using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour {

	public GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activate() {
		for (int i = 0; i < spawnPoints.Length; i++) {
			Debug.Log ("controller activated");
			spawnPoints [i].GetComponent<SpawnScript> ().activate ();
		}
	}

	public void deactivate() {
		for (int i = 0; i < spawnPoints.Length; i++) {
			spawnPoints [i].GetComponent<SpawnScript> ().deactivate ();
		}
	}
}
