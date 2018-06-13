using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour {

	bool isInitialized = false;
	Vector3 origPosition;

	MeshRenderer meshRenderer;
	Material origMaterial;
	[SerializeField] Material offMaterial;

	void init(){
		if (!isInitialized) {
			origPosition = transform.position;

			meshRenderer = GetComponent<MeshRenderer> ();
			origMaterial = meshRenderer.material;

			isInitialized = true;
		}
	}

	// Use this for initialization
	void OnEnable () {
		init ();

		transform.position = origPosition;
		transform.rotation = Quaternion.identity;
		meshRenderer.material = origMaterial;

		CancelInvoke();

		shake ();
	}

	void OnDisable(){
		transform.DOKill ();
	}

	void shake(){
		transform.DOShakePosition (
			duration: 3,
			strength: 5,
			vibrato: 1,
			fadeOut: false).OnComplete (shake);
	}

	public void shoot(){
		transform.DOKill ();
		meshRenderer.material = offMaterial;


		Invoke ("disable", 3);
	}

	void disable(){
		gameObject.SetActive (false);
	}
}
