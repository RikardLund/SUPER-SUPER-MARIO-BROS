using UnityEngine;
using System.Collections;

public class Death_Pit : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		//Debug.Log ("The death pit has been fallen through");
		GM.instance.death();
	}
}
