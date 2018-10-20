using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject meteorPrefab;
	public Transform meteors;

	public Meteor SpawnWord(){
		Vector3 randomPos = new Vector3(Random.Range(-6f, 6f), Random.Range(6.1f, 6f));

		GameObject wordObj = Instantiate(meteorPrefab, randomPos, Quaternion.identity, meteors);

		return  wordObj.GetComponent<Meteor>();
	}
		
}	
