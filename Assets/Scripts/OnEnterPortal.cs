using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class OnEnterPortal : MonoBehaviour {
	public string NextLevel;
	public float decreasingScaleFactor;
	public AudioClip levelCompleteAudioClip;
	public float levelCompleteVolume = 1;


	private bool enteredPortal = false;
	private Vector3 fixedPosition;
	private GameObject player;
	private Vector3 decreasingScale;
	private String currentLvl;
	private Text currentTimer;
	void Start() {
		currentLvl = SceneManager.GetActiveScene().name;
		enteredPortal = false;
		decreasingScale = new Vector3 (decreasingScaleFactor, decreasingScaleFactor, decreasingScaleFactor);
	}

	void FixedUpdate () {
		if (enteredPortal) {
			if (currentLvl != "Level Selector") {
				currentTimer = GameObject.Find ("Timer").GetComponent<Text> ();
				PlayerPrefs.SetString ("bestlvl" + currentLvl, currentTimer.text);
			}
			player.transform.position = fixedPosition;
			player.transform.localScale -= decreasingScale * Time.deltaTime;
			
			if (player.transform.localScale.x <= 0 ||
				player.transform.localScale.y <= 0 ||
				player.transform.localScale.z <= 0) {
				SceneManager.LoadScene(NextLevel);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			AudioSource.PlayClipAtPoint (levelCompleteAudioClip, other.transform.position, levelCompleteVolume);
			enteredPortal = true;
			fixedPosition = other.transform.position;
			player = other.gameObject;
			if (SceneManager.GetActiveScene ().name != "Level Selector") {
				string currentLevel = SceneManager.GetActiveScene ().name;
				PlayerPrefs.SetInt (currentLevel, 2);
				string[] splitString = currentLevel.Split (' ');
				int levelNumber = int.Parse(splitString [1]);
				int nextLevelNumber = levelNumber + 1;
				string nextLevelString = "Level " + nextLevelNumber;
				PlayerPrefs.SetInt (nextLevelString, 1);
			}
		}
	}
}
