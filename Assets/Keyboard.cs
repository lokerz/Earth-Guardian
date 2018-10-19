using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {
	private Manager manager;
	public GameObject[] keys;
	public float size;
	void Start(){
		manager = GameObject.Find ("Manager").GetComponent<Manager> ();
		if (keys == null)
			keys = GameObject.FindGameObjectsWithTag ("Keys");
		foreach(GameObject key in keys){
			key.transform.localScale += Vector3(1.0f-manager.KeySize,1.0f-manager.KeySize,0);
		}
	}

	public void ChangeKeySize(int size){
		if (size == 100)
			manager.KeySize = 1.1f;
		else if (size == 120)
			manager.KeySize = 1.2f;
		else
			manager.KeySize = 1.0f;

		foreach(GameObject key in keys){
			key.transform.localScale += Vector3(1.0f-manager.KeySize,1.0f-manager.KeySize,0);
		}
	}
		
}
