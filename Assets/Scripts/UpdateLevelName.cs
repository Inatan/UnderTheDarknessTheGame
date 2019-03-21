using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UpdateLevelName : MonoBehaviour {

	private Text text;
	// Use this for initialization
	void Start () {
		text = transform.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = SceneManager.GetActiveScene().name;
	}
}
