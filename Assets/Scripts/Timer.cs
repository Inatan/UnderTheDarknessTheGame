using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	private bool timerStopped = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerStopped) {
			return;
		}
		float t = Time.time - startTime;
		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f0");

		timerText.text = minutes + ":" + seconds;
	}

	public void StopTimer()
	{
		timerStopped = true;
		timerText.color = Color.red;
	}

}
