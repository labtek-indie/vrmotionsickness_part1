using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] Menu menu;

	[SerializeField] Transform scenarioRoot;
	Simulation[] scenarios;
	[SerializeField] Simulation scenario;

	string[] scenarioKeys = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "t", "y", "u", "i", "o", "p", "g", "h", "j", "k", "l"};

	SplineController splineController;

	[Header("Manual")]

	CharacterController characterController;

	[SerializeField] float runMultiplier = 2f;

	bool isStartingJump = false;
	float crntYSpeed = 0;

	[SerializeField] float gravity = 40f;

	[SerializeField] Transform neck;

	[SerializeField] float rotSpeed = 1000f;
	Vector3 moveDirection = new Vector3 ();

	Vector2 screenCenter = new Vector2();

	[SerializeField] GameObject crosshair;


	void OnEnable(){
		AppMaster.OnAppStep += step;
		AppMaster.OnAppPause += pause;
		AppMaster.OnScenarioSelect += reset;
	}

	void OnDisable(){
		AppMaster.OnAppStep -= step;
		AppMaster.OnAppPause -= pause;
		AppMaster.OnScenarioSelect -= reset;
	}

	// Use this for initialization
	void Start () {
		scenarios = scenarioRoot.GetComponentsInChildren<Simulation> ();

		menu.init (scenarios);
		menu.gameObject.SetActive (false);

		splineController = GetComponent<SplineController> ();

		characterController = GetComponent<CharacterController> ();

//		Application.targetFrameRate = 10;

		screenCenter.x = Screen.width / 2f;
		screenCenter.y = Screen.height / 2f;

		AppMaster.i.DoScenarioSelect (0);
	}


	void reset(int scenarioIdx = -1){
		if (scenario != null)
			scenario.setActive (false);
		

		if(scenarioIdx >= 0 && scenarioIdx < scenarios.Length){
			scenario = scenarios[scenarioIdx];

			scenario.setActive (true);

			crosshair.SetActive (scenario.canShoot);

			if (!scenario.isControlled) {
				splineController.Duration = scenario.trackDuration;
				splineController.OrientationMode = scenario.trackOrientation;
				splineController.init (scenario.track);
			} else {
				splineController.stop ();

				if (scenario.startingPosition != null)
					transform.TransferTo (scenario.startingPosition);
				else if (scenario.waypointSet != null) {
					scenario.waypointSet.reset ();
					transform.TransferTo (scenario.waypointSet.getCurrent ().transform);
				}
			}
		}
		else
			scenario = null;
	}

	void pause (bool isPaused){
		menu.setActive (isPaused);
	}
	
	// Update is called once per frame
	void step () {

		for (int i = 0; i < scenarioKeys.Length; i++) {
			if (Input.GetKeyDown (scenarioKeys [i])) {
				reset (i);
				break;
			}
		}


		if (scenario.isControlled) {

//		if (Input.GetButton ("0"))
//			print ("0");
//		if (Input.GetButton ("1"))
//			print ("1");
//		if (Input.GetButton ("2"))
//			print ("2");
//		if (Input.GetButton ("3"))
//			print ("3");
//		if (Input.GetButton ("4"))
//			print ("4");
//		if (Input.GetButton ("5"))
//			print ("5");
//		if (Input.GetButton ("6"))
//			print ("6");
//		if (Input.GetButton ("7"))
//			print ("7");
//		if (Input.GetButton ("8"))
//			print ("8");
//		if (Input.GetButton ("9"))
//			print ("9");
		
			// ROTATION

			float lh = Input.GetAxis ("JoystickR X");
//			float lh = Input.GetAxis ("Mouse X");


			if (scenario.lockNeck || Input.GetButton ("Follow View")) {
				float headYaw = Camera.main.transform.rotation.eulerAngles.y;
				float neckYaw = neck.rotation.eulerAngles.y;

				transform.RotateTo (0, headYaw, 0);
				neck.RotateTo (0, neckYaw, 0);

			} else if (Mathf.Abs (lh) > .05f) {
				transform.Rotate (0, lh * rotSpeed * Time.deltaTime, 0);
			}

			// HORIZONTAL MOVEMENT

			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			moveDirection = new Vector3 ();

			float crntRunMultiplier = 1;
			if (Input.GetButton ("Run")) {
				crntRunMultiplier = runMultiplier;
			}

			Vector3 forward = transform.TransformDirection (Vector3.forward);
			moveDirection += forward * (((v > 0) ? scenario.fwdSpeed : scenario.fwdSpeed * .5f) * v) * crntRunMultiplier;

			Vector3 right = transform.TransformDirection (Vector3.right);
			moveDirection += right * (scenario.fwdSpeed * h * .7f) * crntRunMultiplier;



			moveDirection *= Time.deltaTime;

			// VERTICAL MOVEMENT

			crntYSpeed -= gravity * Time.deltaTime;

			if (
				characterController.isGrounded &&
				!isStartingJump
			) {
				crntYSpeed = -gravity * Time.deltaTime * 5;

				if(Input.GetButtonDown ("Jump")){
					crntYSpeed = 0;
					isStartingJump = true;
				}
			}

			if (isStartingJump) {
			
				if (!Input.GetButton ("Jump"))
					isStartingJump = false;
				else {
				
					crntYSpeed += scenario.jumpAcceleration * Time.deltaTime;

					if (crntYSpeed >= scenario.maxJumpSpeed)
						isStartingJump = false;
				}
			}
			crntYSpeed = Mathf.Clamp (crntYSpeed, -gravity * 30, scenario.maxJumpSpeed);

			Vector3 up = transform.TransformDirection (Vector3.up);
			moveDirection += up * crntYSpeed;



			characterController.Move (moveDirection);

		}

		if (Input.GetButton ("Fire1") && scenario.canShoot) {
			
			Ray ray = Camera.main.ScreenPointToRay(screenCenter);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 1000)) {
				if (hit.collider.gameObject.tag == "Target") {
					Target target = hit.collider.gameObject.GetComponent<Target> ();
					target.shoot ();
				}
			}
		}

	}

	void OnTriggerEnter (Collider col)
	{
		
		if(col.gameObject.tag == "Reset Collider")
		{
			if (scenario.isControlled)
				reset ();
		}
		else if(col.gameObject.tag == "Waypoint")
		{
			if (scenario.waypointSet != null)
				scenario.waypointSet.next ();
		}
	}
}
