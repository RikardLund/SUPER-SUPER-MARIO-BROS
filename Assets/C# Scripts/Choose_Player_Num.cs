using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Choose_Player_Num : MonoBehaviour {
	
	private Animator m_Animator;
	bool mushShow = false;

	void Start () {
		m_Animator = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.Return) && mushShow == false || Input.GetKey (KeyCode.Space) && mushShow == false){
			Application.LoadLevel ("Start Level"); //1 player game start
		}
		if (Input.GetKeyDown (KeyCode.Return) && mushShow == true || Input.GetKey (KeyCode.Space) && mushShow == true){
			//2 player game start
		}
		if (Input.GetButtonDown ("Vertical") && mushShow == true) {
			mushShow = false;
		}
		else if (Input.GetButtonDown ("Vertical") && mushShow == false) {
			mushShow = true;
		}
		m_Animator.SetBool ("mushShow", mushShow);
	}
}
