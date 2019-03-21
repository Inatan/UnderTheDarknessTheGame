using UnityEngine;
using System.Collections;

public class TutorialTextController : MonoBehaviour {
	private TextMesh text;
	private float elapsedTime;
	private bool fadingIn;
	private bool fadingOut;

	public float timeToShow;
	public float timeToHide;
	public float fadingSpeed;
	public string hideAfterLevelComplete;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<TextMesh> ();
		elapsedTime = 0;
		fadingIn = false;
		fadingOut = false;

		// Text starts fully transparent
		text.color = new Color(1, 1, 1, 0);

		// If the player has already completed the first level, this text is irrelevant
		if (PlayerPrefs.GetInt (hideAfterLevelComplete) == 2) {
			this.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= timeToHide) {
			fadingIn = false;
			fadingOut = true;
		} else if (elapsedTime >= timeToShow) {
			fadingOut = false;
			fadingIn = true;
		}

		if (fadingIn) {
			text.color = new Color(1,1,1, text.color.a + fadingSpeed * Time.deltaTime);
			if (text.color.a >= 1) {
				fadingIn = false;
				text.color = new Color(1,1,1,1);
			}
		} else if (fadingOut) {
			text.color = new Color(1,1,1, text.color.a - fadingSpeed * Time.deltaTime);
			if (text.color.a <= 0) {
				fadingOut = false;
				text.color = new Color (1,1,1,0);
				Destroy (gameObject);
			}
		}

	}
}
