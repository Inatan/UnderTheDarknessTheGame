using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TheEndScript : MonoBehaviour {
	private float elapsedTime;

	public float timeToDisplayScene;
	public float fadingTime;
	// Use this for initialization
	void Start () {
		elapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= timeToDisplayScene) {
			gameObject.GetComponent<FadingLevel> ().BeginFade (1);
		}
		if (elapsedTime >= timeToDisplayScene + fadingTime) {
			SceneManager.LoadScene ("Menu");
		}
	}
}
