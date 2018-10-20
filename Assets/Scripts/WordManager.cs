using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {
	public List<Word> words;

	private bool hasActive = false;
	private Word activeWord;

	private Spawner spawner;

	void Start(){
		spawner = GetComponent<Spawner> ();	
	}

	public void SpawnWord(string x){
		Word word = new Word(x, spawner.SpawnWord());
	
		words.Add (word);
	}

	public void Type (string input){
		char x = input [0];
		Debug.Log (hasActive);
		if (hasActive) {
			if (activeWord.GetNextLetter () == x) {
				activeWord.Type ();
			}
		} 
		else {
			foreach (Word word in words) {
				if (word.GetNextLetter () == x) {
					activeWord = word;
					hasActive = true;
					word.Type ();
					break;
				}
			}
		}

		if(hasActive && activeWord.DoneCheck()){
			hasActive = false;
			words.Remove (activeWord);
		}

	}
}
