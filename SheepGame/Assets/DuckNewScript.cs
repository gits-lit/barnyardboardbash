using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DuckNewScript : MonoBehaviour {

	private Rigidbody rb;
	public GameObject camera;
	public int score;
	public DuckTimer duckTimerScript;

	public List<Transform> Chicks = new List<Transform> ();

	public float mindistance = 0.25f;

	public GameObject bodyprefab;

	private float dis;
	private Transform curChick;
	private Transform prevChick;



	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
	}

	void Update () {
		/*float x = CrossPlatformInputManager.GetAxis ("Horizontal");
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

		for (int i = 0; i < Chicks.Count; i++) {
			curChick = Chicks [i];
			if (i == 0) {
				prevChick = gameObject.transform;
			} else {
				prevChick = Chicks [i - 1];
			}

			dis = Vector3.Distance (prevChick.position, curChick.position);

			Vector3 newpos = prevChick.position;

			newpos.y = gameObject.transform.position.y;

			float T = Time.deltaTime * dis / mindistance;

			if (T > 0.5f) {
				T = 0.5f;
			}

			Vector3 tmp = curChick.position;
			tmp.y = 0;
			curChick.position = tmp;

			//curChick.position = Vector3.Slerp (curChick.position, newpos, T);
			curChick.rotation = Quaternion.Slerp (curChick.rotation, prevChick.rotation, T);
		}
	}

	void AddChick() {
		Transform newchick;
		if (Chicks.Count == 0) {
			Debug.Log ("Added first chick");
			newchick = (Instantiate (bodyprefab) as GameObject).transform;
		} else {
			Debug.Log ("Adding more chicks");
			newchick = (Instantiate (bodyprefab) as GameObject).transform;
		}
		newchick.SetParent (transform);
		newchick.localScale += new Vector3(0.4F, 0.4F, 0.4F);

		Chicks.Add (newchick);
		Debug.Log ("Added a chick");
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "Chick")
		{
			Destroy (col.gameObject);
			score++;
			AddChick ();

		}
		else if(col.gameObject.name == "ChickFollower")
		{
			duckTimerScript.GameOver ();
		}
	}*/
	}
}
