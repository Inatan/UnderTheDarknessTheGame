using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Don't destroy object on transitions
	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

}
