using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		if (renderer != null)
			Destroy (renderer);
	}

}
