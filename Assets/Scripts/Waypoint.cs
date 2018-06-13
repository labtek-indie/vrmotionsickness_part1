using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	Collider _collider;

	// Use this for initialization
	public void init () {
		_collider = GetComponent<Collider> ();
	}

}
