using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Player_Movement : MonoBehaviour {

	public float Speed = 10.0f;
	public float JumpSpeed = 0.5f;

	public LayerMask GroundLayers;

	public AudioClip m_jump1;
	public AudioClip pipe;

	private Animator m_Animator;
	private Transform m_Groundcheck1;
	private Transform m_Groundcheck2;

	public int hasExited;

	public bool paused = false;

	void Start() {
		hasExited = PlayerPrefs.GetInt ("exitedPipe");
		m_Animator = GetComponent<Animator> ();
		m_Groundcheck1 = transform.FindChild ("GroundCheck1");
		m_Groundcheck2 = transform.FindChild ("GroundCheck2");

		if (hasExited > 0) {
			this.gameObject.transform.position = new Vector3 (164, 3, 0);
			AudioSource.PlayClipAtPoint (pipe, transform.position);
		}
	}

	void Update() {
		bool isCrouching = false;

		if (Input.GetKey (KeyCode.S)) {
			isCrouching = true;
		}

		bool isGrounded1 = Physics2D.OverlapPoint(m_Groundcheck1.position, GroundLayers);
		bool isGrounded2 = Physics2D.OverlapPoint(m_Groundcheck2.position, GroundLayers);

		if (isGrounded1 != isGrounded2) {
			isGrounded1 = true;
			isGrounded2 = true;
		}

		if (Input.GetButtonDown ("Jump") && paused != true) {

			if (isGrounded1 || isGrounded2) {
				AudioSource.PlayClipAtPoint (m_jump1, transform.position);
				rigidbody2D.AddForce (Vector2.up * JumpSpeed, ForceMode2D.Impulse);
				isGrounded1 = false;
				isGrounded2 = false;
			}
		}

		m_Animator.SetBool ("isCrouching", isCrouching);
		m_Animator.SetBool ("isGrounded1", isGrounded1);
		m_Animator.SetBool ("isGrounded2", isGrounded2);

		float hSpeed = Input.GetAxis ("Horizontal");

		m_Animator.SetFloat ("Speed", Mathf.Abs (hSpeed));

		if (hSpeed > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (hSpeed < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		this.rigidbody2D.velocity = new Vector2(hSpeed * Speed, this.rigidbody2D.velocity.y);

		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel ("Title Screen");
		}
		if (Input.GetKeyDown (KeyCode.P) && paused != true) {
			paused = true;
			Time.timeScale = 0.0f;
		}
		else if (Input.GetKeyDown (KeyCode.P) && paused == true) {
			paused = false;
			Time.timeScale = 1.0f;
		}
	}
}
