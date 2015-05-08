using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GM : MonoBehaviour {

	public GameObject Question_Blocks_prefab;
	public GameObject Breakable_Blocks_prefab;

	public static GM instance = null;

	public int points = 0;
	public int coins = 0;
	public int lives = 1;
	public int topScore = 0;
	public float timeLeft = 400f;
	public float resetDelay = 2.0f;

	public Text canPoints;
	public Text canTime;
	public Text canOver;

	public bool gameOver = false;
	public bool timeOver = false;
	public bool fastMusicTime = false;
	public bool stopMusicCount = false;
	public bool dead = false;

	public AudioClip normalMusic;
	public AudioClip fastMusic;
	public AudioClip gameOverMusic;

	void Awake() {

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		Application.runInBackground = true;
		DontDestroyOnLoad (gameObject);

		if (fastMusicTime != true) {
			AudioSource.PlayClipAtPoint (normalMusic, transform.position);
		}
	}

	void coinLife() {
		if (coins == 100) {
			coins = 0;
			lives++;
		}
	}

	public void death() {
		lives--;
		dead = true;
		//Time.timeScale = 0.0f;
		gameOver = true;
		Invoke ("toGameOver", resetDelay);
	}

	void toGameOver() {
		Application.LoadLevel ("Game_Over");
	}
	public void destroyBrick() {
		points += 50;
		canPoints.text = "" + points.ToString("D6");
		//Debug.Log (points);
	}

	void Update() {
		if (timeOver != true) {
			if (dead != true) {
				timeLeft -= Time.deltaTime * 2.3f;
				canTime.text = "" + timeLeft.ToString("0");
			}
		}
		if (timeLeft <= 100f && stopMusicCount != true) {
			stopMusicCount = true;
			fastMusicTime = true;
			playFastMusic();
		}
		if (timeLeft <= 0f) {
			timeLeft = 0f;
			timeOver = true;
		}
	}
	public void noTime() {
		if (timeOver == true) {
			death();
		}
	}
	public void playFastMusic() {
		AudioSource.PlayClipAtPoint (fastMusic, transform.position);
	}
}

