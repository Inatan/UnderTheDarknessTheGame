using UnityEngine;
using System.Collections;

public class SpecialKillingLightController : MonoBehaviour {
	private bool dying = false;
	private Light thisLight;
	private SphereCollider thisSphereCollider;
	public float time;
	private float t;
	public float dyingFactor = 1.0f;
	private float startIntensify = 4.0f;
	// Use this for initialization
	void Start () {
		thisLight = gameObject.GetComponent<Light> ();
		thisSphereCollider = gameObject.GetComponent<SphereCollider> ();
	}

	// Update is called once per frame
	void Update () {
		if(t >= 0){
			t -= Time.deltaTime;
		}else{
			if (thisLight.intensity == 0.0f) {
				thisLight.intensity = startIntensify;
			} else {
				thisLight.intensity = 0.0f;
			}
			thisSphereCollider.enabled = !thisSphereCollider.enabled;

			t = time;
		}
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
