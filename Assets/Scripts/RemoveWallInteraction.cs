using UnityEngine;
using System.Collections;

public class RemoveWallInteraction : MonoBehaviour {
	public string wallTag = "RemovableWall";

	// The code for the interaction goes here
	void OnTriggerEnter (Collider other) {
		GameObject[] walls = GameObject.FindGameObjectsWithTag (wallTag);
		foreach(GameObject wall in walls) {
			wall.GetComponent<AudioSource> ().PlayDelayed(0);
			Destroy (wall);
		}

		Destroy (gameObject);
	}
}
