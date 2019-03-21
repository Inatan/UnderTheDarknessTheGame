using UnityEngine;
using System.Collections;

public class BulletTrap : MonoBehaviour {
	public GameObject b ;
	public float time;
	public float speed;
	private BulletScript bs;
	private float t;
	public float angle;
	// Use this for initialization
	void Start () {
		bs = b.GetComponent<BulletScript> ();
		bs.speed = speed;
		t = time;
	}
	
	void FixedUpdate () {
		
		if(t >= 0){
			t -= Time.deltaTime;
		}else{
			Instantiate(b,transform.position,Quaternion.AngleAxis(angle,new Vector3(0,0,1.0f)));
			t = time;
		}

	}

}
