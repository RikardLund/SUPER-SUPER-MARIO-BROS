using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title_Screen : MonoBehaviour {

	public int points = 0;
	public int coins = 0;
	public int topScore = 0;

	public float startDelay = 3.0f;

	public Text canPoints;
	public Text canTime;
	public Text canCoins;
	public Text canHigh;

	void Awake() {
		canHigh.text = "TOP- " + topScore.ToString("D6");
	}
	
	void Update () {
	
	}
}
