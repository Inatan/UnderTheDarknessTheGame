using System;
using UnityEngine;
using System.Collections;

public class KillingLightController : MonoBehaviour {
	private bool dying = false;
	private Light thisLight;

	public float dyingFactor = 1.0f;
	// Use this for initialization
	void Start () {
		thisLight = gameObject.GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		if (dying) {
			thisLight.intensity -= dyingFactor * Time.deltaTime;
			if (thisLight.intensity <= 1.5) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject target = other.gameObject;
		if (target.tag == "Enemy") {
			EnemyController enemyController = target.GetComponent<EnemyController> ();
			enemyController.Die ();
			dying = true;
		} else if (target.tag == "Player") {
			PlayerController playerController = target.GetComponent<PlayerController> ();
			playerController.Die ();
			dying = true;
		}
	}
}
