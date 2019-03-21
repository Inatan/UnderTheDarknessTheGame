using UnityEngine;
using System.Collections;

public class EnemyFootstepController : MonoBehaviour {
	private EnemyController enemyController;
	private AudioSource audioSource;
	private float secondsToStep;

	public float secondsPerStep;

	// Use this for initialization
	void Start () {
		enemyController = gameObject.GetComponent<EnemyController> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		secondsToStep = secondsPerStep;
	}

	void FixedUpdate () {
		if (enemyController.isMoving ()) {
			secondsToStep -= Time.deltaTime;
			if (secondsToStep < 0) {
				secondsToStep = secondsPerStep;
				audioSource.Play ();
			}
		}
	}
}
