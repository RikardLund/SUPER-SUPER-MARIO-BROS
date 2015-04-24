using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	void Awake() {
		Application.runInBackground = true;

		DontDestroyOnLoad (gameObject);
	}

	void Start() {

	}

	void Update() {

	}
}
