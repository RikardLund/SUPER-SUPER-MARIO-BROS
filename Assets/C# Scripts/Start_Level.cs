using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Level : MonoBehaviour {

	public int points = 0;
	public int coins = 0;
	public int lives;
	public int topScore = 0;

	public float startDelay = 3.0f;
	
	public Text canPoints;
	public Text canCoins;
	public Text canLives;

	void Awake() {
		PlayerPrefs.SetFloat ("timeRemaining", 400f);
		PlayerPrefs.SetInt ("currentCoins", 0);
		PlayerPrefs.SetInt ("currentPoints", 0);
		PlayerPrefs.SetInt ("exitedPipe", 0);
		lives = PlayerPrefs.GetInt("currentLives");
		canLives.text = "" + lives;
		Invoke ("startGame", startDelay);
	}

	void startGame() {
		Application.LoadLevel ("World 1-1");
	}

	public void checkTopScore() {
		if (points > topScore) {
			topScore = points;
		}
	}

	void Update() {
		if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.Space)) {
			startGame ();
		}
	}
}
