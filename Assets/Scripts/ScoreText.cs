using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour {
	public TextMeshProUGUI textBox;

	void Update () {
		textBox.text = StageManager.score.ToString ();
	}
}
