using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title_Screen : MonoBehaviour {

	public int points = 0;
	public int coins = 0;
	public int topScore;

	public float startDelay = 3.0f;

	public Text canPoints;
	public Text canTime;
	public Text canCoins;
	public Text canHigh;
	
	void Awake() {
		//PlayerPrefs.SetInt("Highscore", 0); //Un-comment this line and start the game to reset the highscore. Then comment this line again to re-enable highscore saves
		PlayerPrefs.SetInt ("exitedPipe", 0);
		topScore = PlayerPrefs.GetInt("Highscore");
		canHigh.text = "TOP- " + topScore.ToString("D6");

	}
	
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
