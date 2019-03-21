using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class UpdateRoomNumber : MonoBehaviour {

	public Text roomNumber;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().name == "Level Selector") {
			roomNumber.text = "Select Level";
		} else {
			string[] splitString = SceneManager.GetActiveScene ().name.Split (' ');
			int levelNumber = int.Parse (splitString [1]);
			roomNumber.text = "Room " + levelNumber;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
