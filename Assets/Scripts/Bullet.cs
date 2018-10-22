using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public static bool isShooting = false;
	public static Transform targetShooting;
	public float speed;
	private Vector3 v_diff;
	private float atan2;

	void Update () {
		if (isShooting) {
			v_diff = (targetShooting.position - transform.position);
			atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);
			transform.rotation = Quaternion.Euler (0f, 0f, (atan2 * Mathf.Rad2Deg) - 90);
			transform.position = Vector2.MoveTowards (transform.position, targetShooting.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Meteor") {
			Destroy (this.gameObject);
		}
	}

}
