using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int level;
	public int levelDifficulty;
	public int maxLettersPerLevel;
	public List<string> wordsPerLevel;
	public float nextWordTime = 0f;
	public float delay = 1.5f;

	private int availableLetters;
	private WordManager wordManager;
	private WordGenerator wordGenerator;
	private bool inLevel;
	private int index = 0;
	private int i = 0;

	void Start (){
		
		wordManager = GameObject.Find ("WordManager").GetComponent<WordManager> ();
		wordGenerator = GameObject.Find ("WordManager").GetComponent<WordGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Manager.inGame) {
			if (inLevel) {
				if (i >= index)
					inLevel = false;
				if (Time.time >= nextWordTime) {
					wordManager.SpawnWord (wordsPerLevel [i]);
					i++;
					nextWordTime = Time.time + delay;
					delay *= 0.99f - (0.01f * level);
				}
			}
		}
	}

	public void StartLevel(int level){
		i = 0;		
		if (level <= 5)
			maxLettersPerLevel = 5;
		else
			maxLettersPerLevel = 10;
		levelDifficulty = level * level + 15;
		availableLetters = levelDifficulty;

		while (availableLetters > 0) {
			bool valid = true;
			string temp = wordGenerator.RandomWord ();
			if (temp.Length <= maxLettersPerLevel) {
				
				for (int i = 0; i < index; i++)
					if (temp [0] == wordsPerLevel [i] [0])
						valid = false;
				if (valid) {
					wordsPerLevel.Add (temp);
					index++;
					availableLetters -= temp.Length;
				}
			}
		}
	
		inLevel = true;
	}

}
