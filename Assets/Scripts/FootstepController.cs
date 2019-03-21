using UnityEngine;
using System.Collections;

public class FootstepController : MonoBehaviour {
	private PlayerController playerController;
	private AudioSource audioSource;
	public float distanceToFootstep;

	public float stepSize = 0.7f;

	// Use this for initialization
	void Start () {
		playerController = gameObject.GetComponent<PlayerController> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		distanceToFootstep = stepSize;
	}
	
	void FixedUpdate () {
		distanceToFootstep -= playerController.getMovement ().magnitude;
		if (distanceToFootstep < 0) {
			distanceToFootstep = stepSize;
			audioSource.Play ();
		}
	}
}
