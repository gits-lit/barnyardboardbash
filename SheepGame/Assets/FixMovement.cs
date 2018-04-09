using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion q = transform.rotation;
		q.eulerAngles = new Vector3 (0, q.eulerAngles.y, 0);
		transform.rotation = q;

		Vector3 tmp = transform.position;
		tmp.y = 0;
		transform.position = tmp;
	}
}
