using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {
	public void RemovePlayerPrefs() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt ("Level 1", 1);
	}
}
