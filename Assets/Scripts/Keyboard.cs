using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {
	public GameObject keyboard1;
	public GameObject keyboard2;
	public GameObject keyboard3;
	public GameObject keyboard4;

	public void QWERTY(){
		keyboard1.SetActive (true);
		keyboard2.SetActive (false);
		keyboard3.SetActive (false);
		keyboard4.SetActive (false);
	}
	public void QWERTZ(){
		keyboard1.SetActive (false);
		keyboard2.SetActive (true);
		keyboard3.SetActive (false);
		keyboard4.SetActive (false);
	}
	public void AZERTY(){
		keyboard1.SetActive (false);
		keyboard2.SetActive (false);
		keyboard3.SetActive (true);
		keyboard4.SetActive (false);
	}
	public void DVORAK(){
		keyboard1.SetActive (false);
		keyboard2.SetActive (false);
		keyboard3.SetActive (false);
		keyboard4.SetActive (true);
	}
}
