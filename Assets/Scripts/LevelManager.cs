using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int level;
	public int levelDifficulty;
	public int maxLettersPerLevel;
	public List<string> wordsPerLevel;
	public float nextWordTime = 0f;
	public float delay = 3f;
	public bool nextBoss = true;
	public bool isBossStage = false;

	private int availableLetters;
	private WordManager wordManager;
	private WordGenerator wordGenerator;
	private int index = 0;
	private int i = 0;
	private int minLength;


	void Start (){
		delay = 3f;
		wordManager = GameObject.Find ("WordManager").GetComponent<WordManager> ();
		wordGenerator = GameObject.Find ("WordManager").GetComponent<WordGenerator> ();

		level = StageManager.level;
		if (level % 5 == 0)
			isBossStage = true;
	}

	void Update () {
		if (isBossStage) {
			if (nextBoss) {
				wordManager.SpawnBoss (wordsPerLevel [i]);
				nextBoss = false;
				if (wordsPerLevel [i].Length == minLength)
					isBossStage = false;
				i++;
			}
		} else {
			if (Time.time >= nextWordTime && i < index) {
				wordManager.SpawnWord (wordsPerLevel [i]);
				i++;
				nextWordTime = Time.time + delay;
				delay *= 0.99f - (0.0001f * level);
			}
		}
	}

	public void StartLevel(int level){
		if (isBossStage) {
			int length = 6 + level/5;
			while(wordsPerLevel.Count != 5){
				string temp = wordGenerator.RandomWord ();
				if (temp.Length == length) {
					wordsPerLevel.Add (temp);
					index++;
					minLength = length;
					length--;
				}
			}
		} else {
			i = 0;		
			if (level <= 5)
				maxLettersPerLevel = 5;
			else if (level <= 10)
				maxLettersPerLevel = 8;
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
		}
	}

}
