using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Break_Block : MonoBehaviour {

	public GameObject brickParticle1;
	//public GameObject brickParticle2;
	//public GameObject brickParticle3;
	//public GameObject brickParticle4;
	public AudioClip break1;
	
	void OnTriggerEnter2D (Collider2D coll) {
		AudioSource.PlayClipAtPoint (break1, transform.position);
		Instantiate (brickParticle1, transform.position, Quaternion.identity);
		//Instantiate (brickParticle2, transform.position, Quaternion.identity);
		//Instantiate (brickParticle3, transform.position, Quaternion.identity);
		//Instantiate (brickParticle4, transform.position, Quaternion.identity);
		GM.instance.destroyBrick();
		Destroy (gameObject);
	}
}
