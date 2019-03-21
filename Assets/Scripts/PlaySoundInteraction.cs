using UnityEngine;
using System.Collections;

public class PlaySoundInteraction : MonoBehaviour {
	public AudioClip audioClip;
	public Transform sourceTransform;
	public float volume = 1;
	
	void OnTriggerEnter() {
		AudioSource.PlayClipAtPoint (audioClip, sourceTransform.position, volume);
	}
}
