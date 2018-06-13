using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		List<MeshFilter> meshes = transform.GetComponentsInAllChildren<MeshFilter> ();
		foreach (MeshFilter mesh in meshes) {
			Destroy (mesh);
		}
	}

}
