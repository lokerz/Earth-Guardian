using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	[Range(1.0f, 1.2f)]
	public float KeySize = 1.0f;
	public static bool inGame = false;


	public GameObject mainMenu;
	public GameObject gameplay;
	public GameObject option;
	public GameObject pause;
	public GameObject gameOver;

	private GameObject plane;
	private WordManager wordManager;
	private LevelManager levelManager;
	private bool isOption = false;

	void Start () {
		if (mainMenu != null) mainMenu.SetActive (true);
		if (gameplay != null) gameplay.SetActive (false);
		if (option != null) option.SetActive (false);
		if (pause != null) pause.SetActive (false);
		if (gameOver != null) gameOver.SetActive (false);

		plane = GameObject.Find ("Plane");
		plane.GetComponent<SpriteRenderer> ().enabled = false;

		wordManager = GameObject.Find ("WordManager").GetComponent<WordManager>();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		
	}

	void Update () {
		
	}

	public void Play (){
		if (isOption == false) {
			if (mainMenu != null)
				mainMenu.SetActive (false);
			if (gameplay != null)
				gameplay.SetActive (true);
			inGame = true;
			plane.GetComponent<SpriteRenderer> ().enabled = true;
			levelManager.StartLevel (1);
		}
	}

	public void Option (){
		if (option != null && isOption == false) {
			option.SetActive (true);
			isOption = true;
		}
		else if (option != null && isOption == true){
			option.SetActive (false);
			isOption = false;
		}
	}

	public void ChangeKeySize(float size){
		KeySize = size;
	}
}
