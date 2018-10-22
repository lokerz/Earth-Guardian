using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Streak : MonoBehaviour {
	public TextMeshProUGUI textBox;

	void Update () {
		textBox.text = StageManager.streak.ToString () + " : " + StageManager.multiplier.ToString ()+".0x";
	}
}
