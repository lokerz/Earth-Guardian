using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {
	private static string[] wordList;
	public TextAsset wordDB;

	void Awake(){
		wordList = wordDB.text.Split (new[]{"\n","\r"},StringSplitOptions.RemoveEmptyEntries);
	}
		

	public string RandomWord(){
		int randIndex = UnityEngine.Random.Range (0, wordList.Length);

		return (wordList [randIndex]);
	}
}
