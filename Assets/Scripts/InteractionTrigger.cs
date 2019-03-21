using UnityEngine;
using System.Collections;

public class InteractionTrigger : MonoBehaviour {

	// The code for the interaction goes here
	void OnTriggerEnter (Collider other) {
		Debug.Log ("Collided with the interaction object");
		Destroy (gameObject);
	}
}
