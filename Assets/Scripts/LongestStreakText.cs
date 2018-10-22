using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LongestStreakText : MonoBehaviour {
		public TextMeshProUGUI textBox;

		void Update () {
			textBox.text = StageManager.longestStreak.ToString ();
		}
	}
