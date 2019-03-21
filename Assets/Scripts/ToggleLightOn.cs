using UnityEngine;
using System.Collections;

public class ToggleLightOn : MonoBehaviour {
	public Light thisLight;
	private float lightIntensity;

	// Use this for initialization
	void Start () {
		lightIntensity = thisLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (thisLight.intensity > 0) {
				thisLight.intensity = 0;
			} else {
				thisLight.intensity = lightIntensity;
			}
		}
	}
}
