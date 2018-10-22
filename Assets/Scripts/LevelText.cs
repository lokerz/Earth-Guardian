using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelText : MonoBehaviour {
	public TextMeshProUGUI textBox;
	public Text textBox2;

	void Start () {
		if (textBox != null)
			textBox.text = "LEVEL " + (StageManager.level);
		else if (textBox2 != null)
			textBox2.text = "You Reached Level " + StageManager.level;
	}
}
