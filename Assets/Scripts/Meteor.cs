using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Meteor : MonoBehaviour {
	public TextMeshPro textBox;
	public float speed;
	public static bool isDestroyable = false;
	private float wordLength;
	private int pointPerWord;
	private string word;
	private WordManager wordManager;
	private AudioSource blast;

	void Start () {
		blast = GameObject.Find ("Blast").GetComponent<AudioSource> ();
		wordManager = GameObject.Find ("WordManager").GetComponent<WordManager>();
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
		transform.GetChild(0).localScale = new Vector3 ( wordLength * 0.04f, wordLength * 0.04f);
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
		StartCoroutine ("DeleteObject");
		blast.Play ();
	}

	IEnumerator DeleteObject(){
		yield return new WaitForSeconds (0.5f);
		Plane.isLooking = false;
		Plane.isFiring = false;
		StageManager.score += pointPerWord * StageManager.multiplier;
		wordManager.RemoveFromList (word);
		Destroy (gameObject);
	}
}
