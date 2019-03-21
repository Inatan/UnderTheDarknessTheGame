using UnityEngine;
using System.Collections;

public class GlowingLight : MonoBehaviour {
	public float glowMin;
	public float glowMax;
	public float glowingSpeed;

	private Light thisLight;
	private bool fading;

	// Use this for initialization
	void Start () {
		thisLight = gameObject.GetComponent<Light> ();
		fading = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			thisLight.intensity -= glowingSpeed * Time.deltaTime;
			if (thisLight.intensity <= glowMin) {
				fading = false;
			}
		} else {
			thisLight.intensity += glowingSpeed * Time.deltaTime;
			if (thisLight.intensity >= glowMax) {
				fading = true;
			}
		}
	}
}
