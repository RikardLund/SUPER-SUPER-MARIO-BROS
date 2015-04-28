using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Break_Block : MonoBehaviour {

	public GameObject brickParticle;
	public AudioClip break1;

	void OnTriggerEnter2D (Collider2D coll) {
		AudioSource.PlayClipAtPoint (break1, transform.position);
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.destroyBrick();
		Destroy (gameObject);
	}
}
