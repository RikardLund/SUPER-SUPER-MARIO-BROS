using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GM : MonoBehaviour {

	//public GameObject Question_Blocks_prefab;
	//public GameObject Breakable_Blocks_prefab;

	public static GM instance = null;

	public int points;
	public int coins;
	public int lives;
	public int topScore;
	public float timeLeft;
	public float resetDelay = 2.0f;

	public Text canPoints;
	public Text canTime;
	public Text canOver;
	public Text canCoin;

	public bool gameOver = false;
	public bool timeOver = false;
	public bool fastMusicTime = false;
	public bool stopMusicCount = false;
	public bool dead = false;
	public bool fromPipe = false;

	public AudioClip normalMusic;
	public AudioClip fastMusic;
	public AudioClip gameOverMusic;
	
	void Awake() {

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		lives = PlayerPrefs.GetInt ("currentLives");
		topScore = PlayerPrefs.GetInt ("Highscore");
		coins = PlayerPrefs.GetInt ("currentCoins");
		points = PlayerPrefs.GetInt ("currentPoints");
		timeLeft = PlayerPrefs.GetFloat ("timeRemaining");
		canCoin.text = "" + coins.ToString("D2");
		canPoints.text = "" + points.ToString("D6");

		if (fastMusicTime != true) {
			AudioSource.PlayClipAtPoint (normalMusic, transform.position);
		}
	}
	public void setTime() {
		PlayerPrefs.SetFloat ("timeRemaining", timeLeft);
	}

	public void pickupCoin() {
		if (coins == 100) {
			coins = 0;
			points += 200;
			lives++;
			PlayerPrefs.SetInt ("currentPoints", points);
			canPoints.text = "" + points.ToString("D6");
			PlayerPrefs.SetInt ("currentCoins", coins);
			canCoin.text = "" + coins.ToString("D2");
			PlayerPrefs.SetInt ("currentLives", lives);
		} else {
			coins++;
			points += 200;
			PlayerPrefs.SetInt ("currentPoints", points);
			canPoints.text = "" + points.ToString("D6");
			PlayerPrefs.SetInt ("currentCoins", coins);
			canCoin.text = "" + coins.ToString("D2");
		}
	}

	public void death() {
		lives--;
		PlayerPrefs.SetInt("currentLives", lives);
		dead = true;
		if (lives < 0) {
			gameOver = true;
			Invoke ("toGameOver", resetDelay);
		} else {
			Invoke ("toLevelStart", resetDelay);
		}
	}

	void toLevelStart() {
		Application.LoadLevel ("Start Level");
	}

	void toGameOver() {
		Application.LoadLevel ("Game_Over");
	}

	void toTitleScreen() {
		Application.LoadLevel ("Title Screen");
	}
	public void coinQuestionBlock() {
		points += 200;
		coins++;
		PlayerPrefs.SetInt ("currentPoints", points);
		canPoints.text = "" + points.ToString("D6");
		PlayerPrefs.SetInt ("currentCoins", coins);
		canCoin.text = "" + coins.ToString("D2");
	}

	public void destroyGoomba() {
		points += 100;
		PlayerPrefs.SetInt ("currentPoints", points);
		canPoints.text = "" + points.ToString("D6");
	}

	public void destroyBrick() {
		points += 50;
		PlayerPrefs.SetInt ("currentPoints", points);
		canPoints.text = "" + points.ToString("D6");
	}

	public void playFastMusic() {
		AudioSource.PlayClipAtPoint (fastMusic, transform.position);
	}

	public void win() {
		dead = true;
		int timeToPoints = (int)Mathf.Round(timeLeft);
		points += (timeToPoints * 100);
		canPoints.text = "" + points.ToString("D6");

		if (points > topScore) {
			topScore = points;
			PlayerPrefs.SetInt("Highscore", topScore);
			Debug.Log(topScore);
		}
		Invoke ("toTitleScreen", resetDelay);
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
			death();
		}
	}
}