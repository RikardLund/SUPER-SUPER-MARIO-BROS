using UnityEngine;
using System.Collections;

public class Death_Pit : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		GM.instance.death();
	}
}
