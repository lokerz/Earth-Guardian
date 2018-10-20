using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Meteor : MonoBehaviour {
	public TextMeshPro textBox;
	public float speed;
	private LevelManager levelManager;
	private float wordLength;

	void Start () {
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();	
		SetSpeed ();
		SetSize ();
	}

	void Update () {
		Debug.Log (speed * Time.deltaTime);
		transform.Translate(0f, -speed * Time.deltaTime, 0f);
	}

	public void SetWord(string word){
		textBox = GetComponentInChildren<TextMeshPro> ();
		textBox.text = word;
		wordLength = word.Length;
	}

	public void SetSpeed(){
		float level = levelManager.level;
		speed = 0.75f - (wordLength / 10) + (level/20); 

	}
	public void SetSize(){
		transform.GetChild(0).localScale = new Vector3 ( wordLength * 0.03f, wordLength * 0.03f);
	}
	public void RemoveLetter(){
		textBox.text = textBox.text.Remove (0,1);
		textBox.color = Color.cyan;
	}

	public void RemoveWord(){
		Destroy(gameObject);
	}
}
