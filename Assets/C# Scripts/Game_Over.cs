using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour {

	public int points = 0;
	public int coins = 0;
	public int lives = 0;
	public int topScore = 0;
	public float timeLeft = 400f;

	public Text canPoints;
	public Text canTime;
	public Text canOver;
	public Text canCoins;

	void Awake() {
	}

	public void checkTopScore() {
		if (points > topScore) {
			topScore = points;
		}
	}

	void Update() {
		if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel ("Title Screen");
		}
	}
}

