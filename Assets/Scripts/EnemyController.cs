using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private CharacterController thisCharacterController;
	private GameObject targetGameObject;
	private Transform targetTransform;
	private Light playerLight;
	private Vector3 movement;
	private Vector3 lastPosition;
	private bool dying = false;

	public bool followingTarget;
	public float dyingFactor = 1f;
	public float speed = 1;

	// Use this for initialization
	void Start () {
		thisCharacterController = gameObject.GetComponent<CharacterController> ();
		targetGameObject = GameObject.FindGameObjectWithTag ("Player");
		targetTransform = targetGameObject.transform;
		playerLight = targetGameObject.GetComponentInChildren<Light> ();
		lastPosition = transform.position;

	}

	void FixedUpdate() {
		lastPosition = transform.position;
		if (!dying) {
			// If the light is on, the enemy follows the player
			if (playerLight.intensity > 0 && SearchPlayer () == true) {
				followingTarget = true;
			} else {
				followingTarget = false;
			}

			if (followingTarget) {
				movement = targetTransform.position - transform.position;
				movement.z = 0;
				movement = transform.TransformDirection (movement);
				movement = movement.normalized * speed * Time.deltaTime;
				thisCharacterController.Move (movement);
			} else {
				movement.x = movement.y = movement.z = 0.0f;
			}

		} else {
			Vector3 newScale = transform.localScale;
			newScale.x -= dyingFactor * Time.deltaTime;
			newScale.y -= dyingFactor * Time.deltaTime;
			transform.localScale = newScale;

			if (transform.localScale.x < 0) {
				Destroy (gameObject);
			}
		}
	}

	// Returns true if the enemy can see the player
	bool SearchPlayer() {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, (targetTransform.position - transform.position), out hit)) {
			if (hit.transform.gameObject.tag == "Player") {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	public void Die() {
		dying = true;
	}

	public bool isMoving() {
		return (lastPosition != transform.position);
	}
}
