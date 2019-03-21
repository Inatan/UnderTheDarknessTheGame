using UnityEngine;
using System.Collections;

public class DestroyObjectInteraction : MonoBehaviour {
	public string objectTag = "RemovableWall";
	private AudioSource destroyedObjectAudioSource;

	// The code for the interaction goes here
	void OnTriggerEnter (Collider other) {
		GameObject[] objects = GameObject.FindGameObjectsWithTag (objectTag);
		foreach(GameObject obj in objects) {
			Destroy (obj);
		}

		Destroy (gameObject);
	}
}
