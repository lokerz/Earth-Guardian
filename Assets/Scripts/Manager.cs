using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject option;

	private StageManager stageManager;
	private PlayerConfig pConfig;
	private bool isOption = false;

	void Start () {
		pConfig = GetComponent<PlayerConfig> ();
		stageManager = GameObject.Find ("StageManager").GetComponent<StageManager> ();

		if (mainMenu != null) mainMenu.SetActive (true);
		if (option != null) option.SetActive (false);
		
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape) && isOption)
			Option ();
		else if(Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
	public void Play (){
		if (isOption == false) {
			StageManager.level = 1;
			stageManager.LoadLevel ();
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
			pConfig.SetConfig ();
		}
	}
		
}
