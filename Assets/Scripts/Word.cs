using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
	private string word;
	private Meteor display;

	public int letterIndex = 0;


	public Word(string _word, Meteor _display){
		word = _word;
		display = _display;

		display.SetWord (word);
	}

	public char GetNextLetter(){
		return word [letterIndex];
	}

	public void Type(){
		letterIndex++;
		display.RemoveLetter ();
	}

	public bool DoneCheck(){
		bool isDone = (letterIndex >= word.Length);
		Debug.Log (isDone);

		if (isDone) {
			display.RemoveWord ();
		}
		return isDone;
	}
}
