using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ChickenCoin : MonoBehaviour {

	private Rigidbody rb;
	public GameObject camera;
	public CollectTimer timerScript;
	public int score;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (x, 0, y);

		rb.velocity = movement * 3f;

		if (x != 0 && y != 0) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}
		//transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		Quaternion q = transform.rotation;
		q.eulerAngles = new Vector3 (0, q.eulerAngles.y, 0);
		transform.rotation = q;

		Vector3 tmp = transform.position;
		tmp.y = 0;
		transform.position = tmp;

		Vector3 dir = transform.position;
		dir = camera.transform.TransformDirection (dir);
		dir.y = 0;
		Vector3.Normalize (dir);

		if (score >= 6) {
			TextMesh collectText = GameObject.Find ("CollectEnd").GetComponent<TextMesh> ();
			collectText.text = "You may advance to the next red space";
			timerScript.victory = true;
		}
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "Egg")
		{
			Destroy(col.gameObject);
			score++;
		}
	}
}
