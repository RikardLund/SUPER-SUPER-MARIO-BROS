using UnityEngine;
using System.Collections;

public class Camera_Move_Zone : MonoBehaviour {

	public int hasExited;

	public bool inCam = false;

	void Start() {
		hasExited = PlayerPrefs.GetInt ("exitedPipe");
		if (hasExited > 0) {
			this.gameObject.transform.position = new Vector3 (176.25f, 5.67f, 0f);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		inCam = true;

	}
	void OnTriggerExit2D (Collider2D col) {
		inCam = false;
	}

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.D) && inCam == true && transform.position.x < 203 || Input.GetKey (KeyCode.RightArrow) && inCam == true && transform.position.x < 203) {
			transform.position += transform.right = new Vector2(0.2f, 0f);

		}
	}
}
