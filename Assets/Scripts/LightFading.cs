using UnityEngine;
using System.Collections;

public class LightFading : MonoBehaviour {
	private Light thisLight;
	private float lightIntensity;
	private bool fadingIn = false;
	private bool fadingOut = false;

	public float fadingSpeed = 1;

	// Use this for initialization
	void Start () {
		thisLight = gameObject.GetComponent<Light> ();
		lightIntensity = thisLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadingIn) {
			thisLight.intensity += fadingSpeed * Time.deltaTime * lightIntensity;
			if (thisLight.intensity >= lightIntensity) {
				thisLight.intensity = lightIntensity;
				fadingIn = false;
			}
		} else if (fadingOut) {
			thisLight.intensity -= fadingSpeed * Time.deltaTime * lightIntensity;
			if (thisLight.intensity <= 0) {
				thisLight.intensity = 0;
				fadingOut = false;
			}
		}
	}

	public void fadeIn() {
		fadingOut = false;
		fadingIn = true;
	}

	public void fadeOut() {
		fadingIn = false;
		fadingOut = true;
	}
}
