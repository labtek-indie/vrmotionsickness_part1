using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioButton : MonoBehaviour {

	[SerializeField] GameObject selection; 
	[SerializeField] GameObject current; 
	[SerializeField] Text numberText; 

	public void init(int idx){
		selection.SetActive (false);
		current.SetActive (false);

		numberText.text = idx.ToString ();
	}

	public void selectButton(bool isSelected){
		selection.SetActive (isSelected);
	}

	public void setAsCurrent(bool isCurrent){
		current.SetActive (isCurrent);
	}

}
