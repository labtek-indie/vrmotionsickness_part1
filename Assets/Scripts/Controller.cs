using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		float h2 = Input.GetAxis ("JoystickLook X");
		print (h2);

		if (Input.GetButton ("Fire1")) {
			transform.Rotate (0, 0, 1);
		}
		transform.Rotate (v, h, 0);
	}
}
