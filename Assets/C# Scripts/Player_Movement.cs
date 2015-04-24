using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float Speed = 10.0f;
	public float JumpSpeed = 0.5f;

	private Animator m_Animator;

	void Awake() {

	}

	void Start () {
		m_Animator = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		float hSpeed = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump")) {
			rigidbody2D.AddForce (Vector2.up * JumpSpeed, ForceMode2D.Impulse);
		}

		m_Animator.SetFloat ("Speed", Mathf.Abs (hSpeed));

		if (hSpeed > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (hSpeed < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		this.rigidbody2D.velocity = new Vector2(hSpeed * Speed, this.rigidbody2D.velocity.y);
	}
}
