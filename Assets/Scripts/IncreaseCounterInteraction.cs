using UnityEngine;
using System.Collections;

public class IncreaseCounterInteraction : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameObject levelController = GameObject.FindGameObjectWithTag ("LevelController");
			InteractionObjectsCounter counterScript = levelController.GetComponent<InteractionObjectsCounter> ();
			counterScript.increaseCounter ();
			Destroy (gameObject);
		}
	}
}
