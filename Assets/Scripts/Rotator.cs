using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField] private float x = 0;
	[SerializeField] private float y = 0;
	[SerializeField] private float z = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (x, y, z);
	}
}
