using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Coins : MonoBehaviour {
	
	public AudioClip coin;
	
	void OnTriggerEnter2D (Collider2D coll) {
		AudioSource.PlayClipAtPoint (coin, transform.position);
		GM.instance.pickupCoin();
		Destroy (gameObject);
	}
}
