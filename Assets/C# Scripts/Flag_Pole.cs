using UnityEngine;
using System.Collections;

public class Flag_Pole : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		GM.instance.win();
	}
}
