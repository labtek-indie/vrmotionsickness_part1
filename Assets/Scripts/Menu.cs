using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	[SerializeField] Transform scenarioButtonContainer;
	List<ScenarioButton> scenarioButtons = new List<ScenarioButton>();

	int selectionIdx = 0;
	int currentIdx = 0;

	bool rightIsPressed = false;
	bool leftIsPressed = false;
	bool upIsPressed = false;
	bool downIsPressed = false;

	// Use this for initialization
	public void init (Simulation[] scenarios) {
		scenarioButtons.Add (GetComponentInChildren<ScenarioButton> ());

		for (int i = 1; i < scenarios.Length; i++) {
			scenarioButtons.Add (GameObject.Instantiate (scenarioButtons [0], scenarioButtonContainer)); 
		}

		for (int i = 0; i < scenarioButtons.Count; i++) {
			scenarioButtons[i].init(i); 
		}
	}

	public void setActive(bool isActive){
		
		gameObject.SetActive (isActive);

		if(isActive){
			currentIdx = selectionIdx = AppMaster.i.ScenarioIdx;
			updateButtons ();
		}
	}


	void Update(){

		int prevSelectionIdx = selectionIdx;

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		int selectionX = selectionIdx % 5;
		int selectionY = Mathf.FloorToInt(selectionIdx / 5f);

		if (h > .1f) {
			if (!rightIsPressed) {
				selectionX++;
				rightIsPressed = true;
			}
		} else {
			rightIsPressed = false;
		}

		if (h < -.1f) {
			if (!leftIsPressed) {
				selectionX--;
				leftIsPressed = true;
			}
		} else {
			leftIsPressed = false;
		}

		if (v > .1f) {
			if (!upIsPressed) {
				selectionY--;
				upIsPressed = true;
			}
		} else {
			upIsPressed = false;
		}

		if (v < -.1f) {
			if (!downIsPressed) {
				selectionY++;
				downIsPressed = true;
			}
		} else {
			downIsPressed = false;
		}


		if (selectionX < 0)
			selectionX = 4;
		else if(selectionX > 4)
			selectionX = 0;

		if (selectionY < 0)
			selectionY = Mathf.FloorToInt(scenarioButtons.Count / 5f);
		else if(selectionY > Mathf.FloorToInt(scenarioButtons.Count / 5f))
			selectionY = 0;

		selectionIdx = (selectionY * 5) + selectionX;

		selectionIdx = Mathf.Min (selectionIdx, scenarioButtons.Count - 1);

		if(prevSelectionIdx != selectionIdx)
			updateButtons ();

		if (Input.GetButtonDown ("Jump")) {
			AppMaster.i.DoScenarioSelect (selectionIdx);
		}
	}

	void updateButtons(){
		for (int i = 0; i < scenarioButtons.Count; i++) {
			scenarioButtons[i].selectButton(i == selectionIdx); 
			scenarioButtons[i].setAsCurrent(i == currentIdx); 
		}
	}
}
