using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private CharacterController thisCharacterController;
	private bool dying = false;
	private Vector3 movement;
	private Vector3 lastPosition;

	public AudioClip deathAudioClip;
	public float clipVolume;
	public float speed = 1;
	public float dyingSpeed = 1f;

	// Use this for initialization
	void Start () {
		thisCharacterController = gameObject.GetComponent<CharacterController> ();
		lastPosition = transform.position;
	}

	// Physics code go under FixedUpdate
	// FixedUpdate is called once per frame, before physics calculations
	void FixedUpdate() {
		if (!dying) {
			float horizontalMovement = Input.GetAxis ("Horizontal");
			float verticalMovement = Input.GetAxis ("Vertical");

			movement.x = horizontalMovement;
			movement.y = verticalMovement;
			movement.z = 0.0f;
			movement = transform.TransformDirection (movement);
			movement *= speed * Time.deltaTime;
			lastPosition = transform.position;
			thisCharacterController.Move (movement);
		} else {
			Vector3 newScale = transform.localScale;
			newScale.x -= dyingSpeed * Time.deltaTime;
			newScale.y -= dyingSpeed * Time.deltaTime;
			transform.localScale = newScale;

			if (transform.localScale.x < 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject hitSource = other.gameObject;
		if (hitSource.tag == "Enemy") {
			Die ();
		}
	}

	public void Die() {
		if (!dying) {
			AudioSource.PlayClipAtPoint (deathAudioClip, transform.position, clipVolume);
		}
		dying = true;
	}

	public bool getDead(){
		return dying;
	}

	public bool isMoving() {
		return (transform.position != lastPosition);
	}

	public Vector3 getMovement() {
		return movement;
	}
}
