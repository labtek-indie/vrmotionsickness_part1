using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMaster : MonoBehaviour {

	// called on start 
	public delegate void AppStart();
	public static event AppStart OnAppStart;
	public void DoAppStart(){
		if(OnAppStart != null)
			OnAppStart();
	}

	// called on update 
	public delegate void AppStep();
	public static event AppStep OnAppStep;
	public void DoAppStep(){
		if(OnAppStep != null)
			OnAppStep();
	}

	bool isPaused = false;

	// called on pause 
	public delegate void AppPause(bool _isPaused);
	public static event AppPause OnAppPause;
	public void DoAppPause(bool _isPaused){
		
		isPaused = _isPaused;
		
		if(OnAppPause != null)
			OnAppPause(isPaused);
	}

	public int ScenarioIdx { get; private set;}

	// called on scenario selection 
	public delegate void ScenarioSelect(int idx);
	public static event ScenarioSelect OnScenarioSelect;
	public void DoScenarioSelect(int idx){

		ScenarioIdx = idx;

		if(OnScenarioSelect != null)
			OnScenarioSelect(idx);

		if (isPaused)
			DoAppPause (false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Start"))
			DoAppPause (!isPaused);
			
		if (!isPaused)
			DoAppStep ();
		
	}

	// SINGLETON SETUP

	// guarantee this will be always a singleton only - can't use the constructor!
	protected AppMaster () {}

	// private reference only this class can access
	private static AppMaster instance;

	public static bool exists(){
		if (Utils.IsNotNull(AppMaster.instance))
			return true;
		return false;
	}

	// setup instance
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {

			Destroy (this);
		}
	}

	// for waking up
	public void ping(){
	}

	// public reference that other classes will use
	public static AppMaster i
	{
		get
		{
			// if doesn't exist yet, add self
			if(instance == null){
				GameObject parent = GameObject.FindGameObjectWithTag ("AppMaster");
				instance = parent.GetComponent<AppMaster>();
				if(instance == null)
					instance = parent.AddComponent<AppMaster>();
			}
			return instance;
		}
	}
	public void OnDestroy () {
		if (instance == this)
			instance = null;
	}
}
