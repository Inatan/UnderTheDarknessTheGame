using UnityEngine;
using System.Collections;

public class ShowObjectObstacle : MonoBehaviour {

	private Transform target;
	private LightFading lightFading;
	private EnemyController enemyController;
	private bool wasFollowing = false;
	private bool wasClose = true;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		lightFading = transform.GetComponentInChildren<Light>().GetComponent<LightFading>();
		enemyController = gameObject.GetComponent<EnemyController> ();
	}
	
	void FixedUpdate () {
		if (Vector3.Distance (target.position, transform.position) < 1.0f) {
			if (wasClose == false) {
				lightFading.fadeIn ();
				wasClose = true;
			}
		} else {
			if (wasClose) {
				lightFading.fadeOut ();
				wasClose = false;
			}
		}

		if (enemyController.followingTarget) {
			if (wasFollowing == false) {
				lightFading.fadeIn ();
				wasFollowing = true;
			}
		} else {
			if (wasFollowing) {
				lightFading.fadeOut ();
				wasFollowing = false;
			}
		}
	}

}
