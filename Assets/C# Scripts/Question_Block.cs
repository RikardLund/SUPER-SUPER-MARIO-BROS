using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Question_Block : MonoBehaviour {

	public GameObject brownBlock;
	public AudioClip hit;

	void OnTriggerEnter2D (Collider2D coll) {
			AudioSource.PlayClipAtPoint (hit, transform.position);
			GM.instance.coinQuestionBlock();
			Destroy (gameObject);
			Instantiate (brownBlock, transform.position, Quaternion.identity);
	}
}
