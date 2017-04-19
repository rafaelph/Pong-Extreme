using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public Text scoreText;
	public Rigidbody2D racket;
	public Rigidbody2D Ball;
	public float RacketSpeed;
	public float BallSpeed;

	private bool upButtonPress = false;
	private bool downButtonPress = false;

	private bool hasGameStarted = false;

	private ScoreManager scoreManager = ScoreManager.getInstance();

	void Update() {
		if (downButtonPress && upButtonPress) {
			stopRacket ();
		} else if (downButtonPress) {
			racket.velocity = RacketSpeed * Vector2.down;
		} else if (upButtonPress) {
			racket.velocity = RacketSpeed * Vector2.up;
		} else {
			stopRacket ();
		}
	}

	public void onLeftPlayerScore() {
		scoreManager.increasePlayerOneScore ();
		setScore (scoreManager.getPlayerOneScore (), scoreManager.getPlayerTwoScore ());
	}

	public void onRightPlayerScore() {
		scoreManager.increasePlayerTwoScore ();
		setScore (scoreManager.getPlayerOneScore (), scoreManager.getPlayerTwoScore ());
	}

	public void onUpButtonPress() {
		if (!hasGameStarted) {
			hasGameStarted = true;
			Ball.velocity = new Vector3 (BallSpeed, 0);
		}
		upButtonPress = true;
	}

	public void onUpButtonRelease() {
		upButtonPress = false;
	}

	public void onDownButtonPress() {
		if (!hasGameStarted) {
			hasGameStarted = true;
			Ball.velocity = new Vector3 (BallSpeed, 0);
		}
		downButtonPress = true;
	}

	public void onDownButtonRelease() {
		downButtonPress = false;
	}

	private void stopRacket() {
		racket.velocity = Vector2.zero;
	}

	private void setScore(int leftPlayerScore, int rightPlayerScore) {
		scoreText.text = leftPlayerScore.ToString () + " - " + rightPlayerScore.ToString ();
	}
		
}
