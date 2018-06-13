using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSet : MonoBehaviour {

	bool isInitialized = false;

	Waypoint[] waypoints;
	int crntIdx = -1;

	void Start(){
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void init () {
		if (!isInitialized) {
			waypoints = GetComponentsInChildren<Waypoint> ();
			print (waypoints.ToPrettyString());

			foreach (Waypoint waypoint in waypoints) {
				waypoint.init ();
			}

			isInitialized = true;
		}

	}

	public Waypoint getCurrent(){
		return waypoints [crntIdx];
	}

	public void reset(){

		gameObject.SetActive (true);

		init ();

		foreach (Waypoint waypoint in waypoints) {
			waypoint.gameObject.SetActive (false);
		}

		crntIdx = -1;

		next ();
	}

	public bool next(){
		if (crntIdx >= 0 && crntIdx < waypoints.Length) {
			waypoints[crntIdx].gameObject.SetActive (false);
		}

		crntIdx++;

		if (crntIdx < waypoints.Length) {
			waypoints[crntIdx].gameObject.SetActive (true);
			return false;
		}

		gameObject.SetActive (false);
		return true;
	}

}
