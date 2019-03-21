using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SetBestTime : MonoBehaviour {

	public Text bestTimeText;
	private String currentLvl;

	// Use this for initialization
	void Start () {
		currentLvl = SceneManager.GetActiveScene().name.ToString();
		String currentBest = PlayerPrefs.GetString ("bestlvl"+currentLvl);

		if(currentBest != ""){
			bestTimeText.text = currentBest;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
