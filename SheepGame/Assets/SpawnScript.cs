using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
	public GameObject bull;
	public int spawnChance = 100;
	private bool activated = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {
		if (activated) {
			int randomInt = Random.Range (1, 100);
			if (randomInt <= spawnChance) {
				GameObject newBull = Instantiate (bull, transform.position, transform.rotation);
				newBull.transform.localScale += new Vector3 (1F, 1F, 1F);
			}
		}
	}

	public void activate() {
		Debug.Log ("point activated");
		activated = true;
	}

	public void deactivate() {
		activated = false;
		//GameObject.Find("/DuckGame/DuckMom/Offset").gameObject;
		foreach(GameObject bullObj in GameObject.FindGameObjectsWithTag("bull")) {
			Destroy(bullObj);
		}
	}
}
