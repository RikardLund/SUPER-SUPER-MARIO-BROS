using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Exit_Pipe : MonoBehaviour {

	public AudioClip pipe;

	public bool pipeUsed = false;

	void exitPipe() {
		if (Input.GetKeyDown (KeyCode.D) && pipeUsed != true || Input.GetKeyDown (KeyCode.RightArrow) && pipeUsed != true) {
			pipeUsed = true;
			AudioSource.PlayClipAtPoint (pipe, transform.position);
			PlayerPrefs.SetInt ("exitedPipe", 1);
			Invoke ("toWorld", 2.0f);
			GM.instance.setTime();
		}
	}

	void toWorld() {
		Application.LoadLevel ("World 1-1");
	}

	void OnTriggerEnter2d (Collider2D coll) {
		exitPipe();
	}

	void OnTriggerStay2D (Collider2D coll) {
		exitPipe();
	}
}
