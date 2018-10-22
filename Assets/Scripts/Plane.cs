using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {
	public static bool isLooking = false;
	public static Transform target;
	private Vector3 v_diff;
	private float atan2;

	public static bool isFiring = false;
	public static bool specialBullet = false;
	public GameObject bulletPrefab;
	private GameObject Turret1;
	private GameObject Turret2;
	private int fireNum = 0;
	private AudioSource laser;

	void Start(){
		laser = GameObject.Find ("Laser").GetComponent<AudioSource> ();
		Turret1 = GameObject.Find ("Turret1");
		Turret2 = GameObject.Find ("Turret2");
	}
	void Update () {
		if (isLooking) {
			v_diff = (target.position - transform.position);
			atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);
			transform.rotation = Quaternion.Euler (0f, 0f, (atan2 * Mathf.Rad2Deg) - 90);
		}
		if (isFiring) {
			if (fireNum % 2 == 0) {
				laser.Play ();
				Instantiate (bulletPrefab, Turret1.transform.position, Quaternion.identity, Turret1.transform);
				fireNum++;
				isFiring = false;
			} else {
				laser.Play ();
				Instantiate (bulletPrefab, Turret2.transform.position, Quaternion.identity, Turret2.transform);
				fireNum++;
				isFiring = false;
			}
		
		} 

	}


}
