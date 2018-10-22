using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageManager : MonoBehaviour {
	public static int level;
	public static int score;
	public static int hiScore;
	public static int streak;
	public static int longestStreak;
	public static int barrierCount;
	public static int multiplier;
	public TextMeshProUGUI scoreboard;

	void Awake(){
		level = 1;
		barrierCount = 3;
		streak = 0;
		multiplier = 1;
		hiScore = PlayerPrefs.GetInt ("HiScore", 0);
		DontDestroyOnLoad (this.gameObject);
	}
	void Start(){
		Time.timeScale = 1;
		if (level % 5 == 0)
			barrierCount++;
		if (level == 1)
			streak = 0;
	}
	void Update(){
		if (streak <= 10)
			multiplier = 1;
		else if (streak <= 20)
			multiplier = 2;
		else if (streak <= 50)
			multiplier = 3;
		else if (streak <= 100)
			multiplier = 4;
		else
			multiplier = 5;
		
		if (streak > longestStreak)
			longestStreak = streak;
	}
	public void LoadLevel(){
		SceneManager.LoadScene ("gameplay");
	}
	public void NextLevel(){
		StartCoroutine ("ChangeLevel");
	}

	IEnumerator ChangeLevel(){
		yield return new WaitForSeconds (3);
		level++;
		LoadLevel ();
	}
}
