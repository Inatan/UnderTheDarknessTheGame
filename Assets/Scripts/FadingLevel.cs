using UnityEngine;
using System.Collections;

public class FadingLevel : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed;

	private int drawDepth = -1000;
	public float alpha =  1.0f;
	private int fadeDirection = -1;		// fade in = -1, fade out = 1;

	void OnGUI() {
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}


	public float BeginFade (int direction) {
		fadeDirection = direction;
		return alpha;
	}

	void OnLevelWasLoaded() {
		BeginFade (-1);
	}
}
