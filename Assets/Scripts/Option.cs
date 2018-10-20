using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Option : MonoBehaviour {
	private Manager manager;
	public Button buttonSize1;
	public Button buttonSize2;
	public Button buttonSize3;

	void Start(){
		manager = GameObject.Find ("Manager").GetComponent<Manager> ();
	}

	void Update(){
		

	}
		
}
