using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Goomba : MonoBehaviour {


	public float gSpeed = -3.3f;

	private Animator g_Animator;

	public AudioClip Goomba_Death;

	public bool isCrushed = false;

	public LayerMask GroundLayers;

	private Transform g_Groundcheck1;
	private Transform g_Groundcheck2;

	void Start () {
	
		g_Animator = GetComponent<Animator> ();
		g_Groundcheck1 = transform.FindChild ("GroundCheck1");
		g_Groundcheck2 = transform.FindChild ("GroundCheck2");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		isCrushed = true;
		AudioSource.PlayClipAtPoint (Goomba_Death, transform.position);
		gSpeed = 0.0f;
		Invoke ("goombDeath", 0.3f);
		GM.instance.destroyGoomba();
	}

	void goombDeath() {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (gSpeed < 0) {
			gSpeed = 3.3f;
		} else if (gSpeed > 0) {
			gSpeed = -3.3f;
		}
	}

	void FixedUpdate () {
		g_Animator.SetBool ("isCrushed", isCrushed);

		bool isGrounded1 = Physics2D.OverlapPoint(g_Groundcheck1.position, GroundLayers);
		bool isGrounded2 = Physics2D.OverlapPoint(g_Groundcheck2.position, GroundLayers);

		if (isGrounded1 != true) {
			gSpeed = 3.3f;
		}
		if (isGrounded2 != true) {
			gSpeed = -3.3f;
		}

		rigidbody2D.velocity = new Vector2(gSpeed, rigidbody2D.velocity.y);
	}
}
