using UnityEngine;
using System.Collections;

public class PlayerFootstepController : MonoBehaviour {
	private PlayerController playerController;
	private AudioSource audioSource;
	private float secondsToStep;

	public float secondsPerStep;

	// Use this for initialization
	void Start () {
		playerController = gameObject.GetComponent<PlayerController> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		secondsToStep = secondsPerStep;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerController.isMoving ()) {
			secondsToStep -= Time.deltaTime;
			if (secondsToStep < 0) {
				secondsToStep = secondsPerStep;
				audioSource.Play ();
			}
		}
	}
}
