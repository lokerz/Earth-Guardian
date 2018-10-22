using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour {
	public static float kSize;
	public static float kTransparency;
	public static int kType;
	public static int lType;
	public static bool isReset = false;
	public GameObject keyboard;

	void Start () {
		kSize = PlayerPrefs.GetFloat ("KeySize",1.0f);
		kTransparency = PlayerPrefs.GetFloat ("keyTransparency",255);
		kType = PlayerPrefs.GetInt ("KeyType",0);
		lType = PlayerPrefs.GetInt ("LetterType",0);


		SetKeySize (kSize);
		SetKeyTransparency (kTransparency);
		SetKeyType (kType);

		if (lType == 1)
			SetLetterType (true);
		else
			SetLetterType (false);

	}
	
	public void SetConfig(){
		PlayerPrefs.SetFloat ("KeySize", kSize);
		PlayerPrefs.SetFloat ("keyTransparency",kTransparency);
		PlayerPrefs.SetInt ("KeyType", kType);
		PlayerPrefs.SetInt ("LetterType", lType);
		PlayerPrefs.Save ();
	}

	public void ResetConfig(){
		kSize = 1.0f;
		kTransparency = 255;
		kType = 0;
		lType = 0;
		isReset = true;
		SetConfig ();
	}


	public void SetKeyType(int type){
		
		kType = type;
		if (keyboard != null) {
			switch (type){
			case 0:
				keyboard.GetComponent<Keyboard> ().QWERTY ();
				break;
			case 1:
				keyboard.GetComponent<Keyboard> ().QWERTZ ();
				break;
			case 2:
				keyboard.GetComponent<Keyboard> ().AZERTY ();
				break;
			case 3:
				keyboard.GetComponent<Keyboard> ().DVORAK ();
				break;
			}
			
		}
	}

	public void SetKeySize(float size){
		kSize = size;
		if (keyboard != null) {
			GameObject[] keys = GameObject.FindGameObjectsWithTag ("Keys");
			foreach (GameObject key in keys){
				key.GetComponent<RectTransform> ().sizeDelta = new Vector2 (72 * size, 72 * size);
			}
		}
	}

	public void SetKeyTransparency(float alpha){
		kTransparency = alpha;
		Image tempImage;
		Color tempColor;
		if (keyboard != null) {
			GameObject[] keys = GameObject.FindGameObjectsWithTag ("Keys");
			foreach (GameObject key in keys){
				tempImage = key.GetComponent<Image> ();
				tempColor = tempImage.color;
				tempColor.a = alpha;
				tempImage.color = tempColor;
			}
		}
	}

	public void SetLetterType(bool type){
		if (type)
			lType = 1;
		else
			lType = 0;
	}
}
