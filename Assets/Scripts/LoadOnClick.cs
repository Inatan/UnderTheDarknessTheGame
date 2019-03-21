using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	// Load scene level
	// Obs: Scene must be in the building setting descriptor
	public void LoadScene(int level)
	{
		loadingImage.SetActive (true);
		GameObject bgMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		AudioSource audioSource = bgMusic.GetComponent<AudioSource> ();
		audioSource.Stop ();
		SceneManager.LoadScene (level);
	}

	public void ShowPanel(GameObject panel)
	{
		panel.SetActive (!panel.activeSelf);
	}

	public void ExitGameBtn()
	{
		Application.Quit ();
	}

	public void HidePanel(GameObject panel) {
			panel.SetActive (!panel.activeSelf);
	}

}
