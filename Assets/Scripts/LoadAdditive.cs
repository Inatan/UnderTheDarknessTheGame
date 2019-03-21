using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadAdditive : MonoBehaviour {

	// load scene without destroying the last one
	public void LoadAddOnClick(int level)
	{
		SceneManager.LoadScene (level);
	}
}
