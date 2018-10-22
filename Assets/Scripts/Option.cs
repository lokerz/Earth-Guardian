using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Option : MonoBehaviour {

	void Start(){
		
		GameObject.Find ("SliderSize").GetComponent<Slider> ().value = PlayerConfig.kSize;
		GameObject.Find ("SliderTransparency").GetComponent<Slider> ().value = PlayerConfig.kTransparency;
		GetComponentInChildren<Dropdown> ().value = PlayerConfig.kType;
		if(PlayerConfig.lType == 1)
			GetComponentInChildren<Toggle> ().isOn = true;
		else
			GetComponentInChildren<Toggle> ().isOn = false;
		
	}
	void Update(){
		if (PlayerConfig.isReset) {
			GetComponentInChildren<Toggle> ().isOn = false;
			GameObject.Find ("SliderSize").GetComponent<Slider> ().value = 1.0f;
			GameObject.Find ("SliderTransparency").GetComponent<Slider> ().value = 255f;
			GetComponentInChildren<Dropdown> ().value = 0;
			PlayerConfig.isReset = false;
		}
	}


			
}
