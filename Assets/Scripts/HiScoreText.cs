using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiScoreText : MonoBehaviour {
	public TextMeshProUGUI textBox;

	void Update () {
		textBox.text = StageManager.hiScore.ToString ();
	}
}
