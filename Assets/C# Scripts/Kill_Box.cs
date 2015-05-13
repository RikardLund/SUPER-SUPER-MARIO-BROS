using UnityEngine;
using System.Collections;

public class Kill_Box : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll) {
		GM.instance.death();
	}
}
