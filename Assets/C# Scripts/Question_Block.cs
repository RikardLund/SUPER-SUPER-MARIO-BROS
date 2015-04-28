using UnityEngine;
using System.Collections;

public class Question_Block : MonoBehaviour {

	public GameObject question_block;

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("Broken");
		Destroy (question_block);
	}

	void Start () {
	
	}

	void Update () {
	
	}
}
