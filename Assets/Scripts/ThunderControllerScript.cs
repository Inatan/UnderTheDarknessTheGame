using UnityEngine;
using System.Collections;

public class ThunderControllerScript : MonoBehaviour {
	private float timeSinceLastSecond = 0;
	private Light ambientLight;
	private bool thunderEffectActive = false;
	private float thunderTimeLeft;

	public float probabilityOfThunderPerSecond = 0.01f;
	public AudioClip thunderClip;

	// Use this for initialization
	void Start () {
		ambientLight = GameObject.FindGameObjectWithTag ("AmbientLight").GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSecond += Time.deltaTime;
		if (timeSinceLastSecond >= 1) {
			timeSinceLastSecond = 0;
			float value = Random.value;
			if (value <= probabilityOfThunderPerSecond) {
				AudioSource.PlayClipAtPoint (thunderClip, Vector3.zero);
				thunderTimeLeft = 2.0f;
				thunderEffectActive = true;
			}
		}
		if (thunderEffectActive) {
			thunderTimeLeft -= Time.deltaTime;
			if (thunderTimeLeft > 0) {
				if (Random.value <= 0.3f) {
					ambientLight.intensity = 2;
				} else {
					ambientLight.intensity = 0;
				}
			} else {
				ambientLight.intensity = 0;
				thunderEffectActive = false;
			}
		}
	}
}
