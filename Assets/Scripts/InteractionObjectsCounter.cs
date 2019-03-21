using UnityEngine;
using System.Collections;

public class InteractionObjectsCounter : MonoBehaviour {
	public int targetCounter = 2;
	public GameObject portalToActivate;

	private int currentCounter = 0;

	void Start() {
		currentCounter = 0;
	}

	public void increaseCounter() {
		currentCounter++;
		if (currentCounter >= targetCounter) {
			activatePortal ();
		}
	}

	private void activatePortal() {
		portalToActivate.SetActive (true);
	}
}
