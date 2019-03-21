using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed,xpos,ypos;
	private Vector3 clickPos;   

	void Start() {
		clickPos= new Vector3();
		clickPos.x = xpos;
		clickPos.y = ypos;
	}

	void FixedUpdate(){
		transform.Translate( clickPos * speed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "wall") {
			Destroy (gameObject);
		} else if ( col.gameObject.tag == "Player") {
			PlayerController playerController = col.gameObject.GetComponent<PlayerController> ();
			playerController.Die ();
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Enemy") {	
			EnemyController enemyController = col.gameObject.GetComponent<EnemyController> ();
			enemyController.Die ();
			Destroy (gameObject);
		}
	}
}
