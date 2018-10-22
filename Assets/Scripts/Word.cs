using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
	public string word;
	public Meteor display;
	public MeteorBoss display2;
	public bool isBoss;
	public int letterIndex = 0;

	public Word(string _word, Meteor _display){
		
		word = _word;
		display = _display;
		isBoss = false;
		display.SetWord (word);
	}

	public Word(string _word, MeteorBoss _display){

		word = _word;
		display2 = _display;
		isBoss = true;
		display2.SetWord (word);
	}

	public char GetNextLetter(){
		return word [letterIndex];
	}

	public void Type(){
		letterIndex++;
		if(!isBoss)
		display.RemoveLetter ();
		else
		display2.RemoveLetter ();
	}

	public bool DoneCheck(){
		bool isDone = (letterIndex >= word.Length);

		if (isDone) {
			if(!isBoss)
			display.RemoveWord ();
			else
			display2.RemoveWord ();
		}
		return isDone;
	}
}
