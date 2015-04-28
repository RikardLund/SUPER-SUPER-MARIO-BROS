using UnityEngine;
using System.Collections;

public class Camera_Move_Zone : MonoBehaviour {
	
	public bool inCam = false;

	void OnTriggerEnter2D (Collider2D col) {
		//Debug.Log ("The Zone Has Been Entered");
	}
	void OnTriggerStay2D (Collider2D col) {
		inCam = true;

	}
	void OnTriggerExit2D (Collider2D col) {
		inCam = false;
	}

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.D) && inCam == true && transform.position.x < 203) {
			transform.position += transform.right = new Vector2(0.2f, 0f);

		}
	}
}
