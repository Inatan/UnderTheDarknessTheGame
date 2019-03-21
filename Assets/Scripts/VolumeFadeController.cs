using UnityEngine;
using System.Collections;

public class VolumeFadeController : MonoBehaviour {
	private AudioSource thisAudioSource;
	private bool fadingIn = false;
	private bool fadingOut = false;

	public float fadingSpeed = 1f;
	public float maxVolume = 0.6f;

	// Use this for initialization
	void Start () {
		thisAudioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fadingIn) {
			thisAudioSource.volume += fadingSpeed * Time.deltaTime;
			if (thisAudioSource.volume >= maxVolume) {
				thisAudioSource.volume = maxVolume;
				fadingIn = false;
			}
		} else if (fadingOut) {
			thisAudioSource.volume -= fadingSpeed * Time.deltaTime;
			if (thisAudioSource.volume <= 0) {
				thisAudioSource.volume = 0;
				fadingOut = false;
			}
		}
	}

	void Awake() {
		audioFadeIn ();
	}

	public void audioFadeIn () {
		fadingIn = true;
	}

	public void audioFadeOut() {
		fadingOut = true;
	}
}
