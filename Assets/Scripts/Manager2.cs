using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager2: MonoBehaviour {
	public static bool isPause = false;
	public static bool isGameOver = false;

	public GameObject pause;
	public GameObject gameOver;

	private PlayerConfig pConfig;
	private LevelManager levelManager;

	void Start () {
		if (pause != null) pause.SetActive (false);
		if (gameOver != null) gameOver.SetActive (false);

		pConfig = GetComponent<PlayerConfig> ();

		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();

		//--------------------------------------------

		levelManager.StartLevel (StageManager.level);

		//--------------------------------------------
		
	}
	void Update(){
		if (isGameOver) {
			Time.timeScale = 0;
			if (gameOver != null) gameOver.SetActive (true);
			if (StageManager.score > StageManager.hiScore)
				StageManager.hiScore = StageManager.score;
			PlayerPrefs.SetInt ("HiScore", StageManager.hiScore);
			isGameOver = false;
		}
	}


	public void Pause (){
		if (pause != null && !isPause && !isGameOver) {
			Time.timeScale = 0;
			pause.SetActive (true);
			isPause = true;
		}
		else if (pause != null && isPause && !isGameOver){
			Time.timeScale = 1;
			pause.SetActive (false);
			isPause = false;
			pConfig.SetConfig ();
		}
	}

	public void LoadScene(string load){
		Time.timeScale = 1;
		StageManager.level = 1;
		StageManager.score = 0;
		StageManager.barrierCount = 3;
		StageManager.streak = 0;
		StageManager.longestStreak = 0;
		SceneManager.LoadScene (load);
	}

}
