using UnityEngine;
using System.Collections;

public class LevelSelectorPortalController : MonoBehaviour {
	private OnEnterPortal onEnterPortalScript;
	private string nextLevel;
	private Light pointLight;

	// Use this for initialization
	void Start () {
		onEnterPortalScript = gameObject.GetComponent<OnEnterPortal> ();
		nextLevel = onEnterPortalScript.NextLevel;
		pointLight = gameObject.GetComponentInChildren<Light> (false);

		if (PlayerPrefs.GetInt (nextLevel) == 0) {
			// The level has never been completed and is not the next level
			pointLight.color = (Color.yellow);
			SphereCollider portalCollider = gameObject.GetComponent<SphereCollider> ();
			pointLight.GetComponent<GlowingLight> ().enabled = false;
			portalCollider.enabled = false;
		} else if (PlayerPrefs.GetInt (nextLevel) == 1) {
			// The level has never been completed and it is the next level
			if (nextLevel == "Level 10") {
				pointLight.color = (Color.red);
			} else {
				pointLight.color = (Color.white);
			}

		} else if (PlayerPrefs.GetInt (nextLevel) == 2) {
			// The level has already been completed.
			pointLight.color = (Color.cyan);
			pointLight.GetComponent<GlowingLight> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
