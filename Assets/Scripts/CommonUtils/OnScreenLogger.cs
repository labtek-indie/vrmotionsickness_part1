using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnScreenLogger : MonoBehaviour
{
	bool isInitialized = false;
	Text textField;
	string logText;
	Queue logQueue = new Queue();

	void init(){
		if (!isInitialized) {
			textField = GetComponent<Text> ();
			isInitialized = true;
		}
	}

	void OnEnable () {
		Application.logMessageReceived += HandleLog;
	}

	void OnDisable () {
		Application.logMessageReceived -= HandleLog;
	}

	void HandleLog(string logString, string stackTrace, LogType type){
		logText = logString;
		string newString = "\n [" + type + "] : " + logText;
		logQueue.Enqueue(newString);
		if (type == LogType.Exception)
		{
			newString = "\n" + stackTrace;
			logQueue.Enqueue(newString);
			
		}

		while (logQueue.Count > 15) {
			logQueue.Dequeue ();
		}

		logText = string.Empty;
		foreach(string log in logQueue){
			logText += log;
		}
	}

	void OnGUI () {
		init ();
//		GUILayout.Label(logText);
		textField.text = logText;
	}
}