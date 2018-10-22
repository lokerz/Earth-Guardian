using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteorBoss : MonoBehaviour {
	public TextMeshPro textBox;
	public float speed;
	public static bool isDestroyable = false;
	private float wordLength;
	private int pointPerWord;
	private string word;
	private WordManager wordManager;
	private LevelManager levelManager;
	private Spawner spawner;
	private AudioSource blast;

	void Start () {
		blast = GameObject.Find ("Blast").GetComponent<AudioSource> ();
		spawner = GameObject.Find ("WordManager").GetComponent<Spawner>();
		wordManager = GameObject.Find ("WordManager").GetComponent<WordManager>();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		SetSpeed ();
		SetSize ();
	}

	void Update () {
		transform.Translate(0f, -speed * Time.deltaTime, 0f);
		if (PlayerConfig.lType == 0)
			textBox.text = textBox.text.ToLower ();
		else 
			textBox.text = textBox.text.ToUpper ();			
	}

	public void SetWord(string input){
		word = input;
		textBox = GetComponentInChildren<TextMeshPro> ();
		textBox.text = word;
		wordLength = word.Length;
		pointPerWord = word.Length * StageManager.level;

	}

	public void SetSpeed(){
		float level = StageManager.level;
		speed = 0.6f - (wordLength / 15) + (level/50); 

	}
	public void SetSize(){
		transform.GetChild(0).localScale = new Vector3 ( wordLength * 0.1f, wordLength * 0.1f);
	}

	public void RemoveLetter(){
		Plane.isLooking = true;
		Plane.target = gameObject.transform;
		Plane.isFiring = true;

		Bullet.isShooting = true;
		Bullet.targetShooting = gameObject.transform;


		textBox.text = textBox.text.Remove (0,1);
		textBox.color = Color.cyan;
	}

	public void RemoveWord(){
		blast.Play ();
		StartCoroutine ("DeleteObject");

	}

	IEnumerator DeleteObject(){
		yield return new WaitForSeconds (0.5f);
		Plane.isLooking = false;
		Plane.isFiring = false;
		StageManager.score += pointPerWord * StageManager.multiplier;
		wordManager.RemoveFromList (word);
		spawner.bossPos = gameObject.transform.position;
		Destroy (gameObject);
		levelManager.nextBoss = true;
	}
}
