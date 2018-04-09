using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickScript : MonoBehaviour
{
	public GameObject targ;

	void Start() {
		//targ = GameObject.Find("/DuckGame/DuckMom/Offset").gameObject;
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, 0.1f);
		transform.rotation = targ.transform.rotation;
	}

	public void setTarg(GameObject obj) {
		targ = obj;
	}
}