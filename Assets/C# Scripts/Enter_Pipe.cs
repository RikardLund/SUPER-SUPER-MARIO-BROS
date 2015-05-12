using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Enter_Pipe : MonoBehaviour {

	public AudioClip pipe;

	public bool pipeUsed = false;

	void enterPipe() {
		if (Input.GetKeyDown (KeyCode.S) && pipeUsed != true || Input.GetKeyDown (KeyCode.DownArrow) && pipeUsed != true) {
			pipeUsed = true;
			AudioSource.PlayClipAtPoint (pipe, transform.position);
			Invoke ("toUnderground", 2.0f);
			GM.instance.setTime();
		}
	}

	void toUnderground() {
		Application.LoadLevel ("Underground");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		enterPipe();
	}

	void OnTriggerStay2D (Collider2D coll) {
		enterPipe();
	}
}
