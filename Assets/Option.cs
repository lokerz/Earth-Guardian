using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Option : MonoBehaviour {
	private Manager manager;
	void Start(){
		manager = GameObject.Find ("Manager").GetComponent<Manager> ();
	}
		
}
