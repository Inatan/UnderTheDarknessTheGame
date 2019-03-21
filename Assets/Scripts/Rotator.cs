using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float rotationX, rotationY, rotationZ;

	void Update () {
		transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);
	}
}
