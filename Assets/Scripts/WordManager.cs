using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {
	public List<Word> words;

	private bool isOver = false;
	private bool hasActive = false;
	private Word activeWord;

	private Spawner spawner;
	private StageManager stageManager;
	private LevelManager levelManager;

	void Start(){
		spawner = GetComponent<Spawner> ();	
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		stageManager = GameObject.Find ("StageManager").GetComponent<StageManager>();
	}

	void Update(){
		if (words.Count == 0 && !isOver && !levelManager.isBossStage) {
			isOver = true;
			stageManager.NextLevel ();
		}
			
	}

	public void SpawnWord(string x){
		Word word = new Word(x, spawner.SpawnWord());
	
		words.Add (word);
	}

	public void SpawnBoss(string x){
		Word word = new Word(x, spawner.SpawnBoss());

		words.Add (word);
	}

	public void Type (string input){
		char x = input [0];
		bool isMatch = false;
		if (hasActive) {
			if (activeWord.GetNextLetter () == x) {
				activeWord.Type ();
				StageManager.streak++;
			} else
				StageManager.streak = 0;
		} 
		else {
			foreach (Word word in words) {
				if (word.GetNextLetter () == x) {
					activeWord = word;
					hasActive = true;
					word.Type ();
					isMatch = true;
					break;
				}
			}
			if (isMatch) {
				StageManager.streak++;
				isMatch = false;
			} else
				StageManager.streak = 0;
		}

		if(hasActive && activeWord.DoneCheck()){
			hasActive = false;
			words.Remove (activeWord);
		}

	}

	public void RemoveFromList(string input){
		for(int i = 0; i < words.Count; i++){
			if (words[i].word == input)
				words.Remove (words[i]);
		}
	}

}
