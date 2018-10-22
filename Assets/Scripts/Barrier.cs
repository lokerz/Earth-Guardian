using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour {
	public float speed;
	public float minSize;
	public float maxSize;
	public bool isBarrier;

	private Text barrierCounter;
	private WordManager wordManager;

	void Start(){
		barrierCounter = GameObject.Find ("BarrierCounter").GetComponent<Text> ();
		barrierCounter.text = StageManager.barrierCount.ToString();
	}
	void Update () {
		if (isBarrier) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			gameObject.GetComponent<Transform>().localScale += new Vector3 (speed*Time.deltaTime, speed*Time.deltaTime);
			gameObject.GetComponent<Transform> ().Rotate (0f, 0f, 4);
			if (gameObject.GetComponent<Transform> ().localScale.x >= maxSize) {
				isBarrier = false;
				StageManager.barrierCount--;
				barrierCounter.text = StageManager.barrierCount.ToString();
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<Transform> ().localScale = new Vector3 (minSize, minSize);
			}
		}
	}

	public void BarrierTrigger(){
		
		if (StageManager.barrierCount > 0 && isBarrier == false)
			isBarrier = true;
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Meteor" && isBarrier) {
			other.gameObject.GetComponent<Meteor> ().RemoveWord ();

		}
	}
}
