﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public Text scoreText;
	public PlayerRacket racket;
	public float RacketSpeed;

	public BallBehaviour ballBehaviour;
	private int ballSpeed;

	private bool upButtonPress = false;
	private bool downButtonPress = false;

	private bool hasGameStarted = false;

	private ScoreManager scoreManager = ScoreManager.getInstance();

	public void Start() {
		ballSpeed = ballBehaviour.ballSpeed;
	}

	void Update() {
		if (downButtonPress && upButtonPress) {
			stopRacket ();
		} else if (downButtonPress) {
			racket.setDirection(RacketSpeed * Vector2.down);
		} else if (upButtonPress) {
			racket.setDirection (RacketSpeed * Vector2.up);
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
			ballBehaviour.setMovementDirection (new Vector2 (ballSpeed, 0));
		}
		upButtonPress = true;
	}

	public void onUpButtonRelease() {
		upButtonPress = false;
	}

	public void onDownButtonPress() {
		if (!hasGameStarted) {
			hasGameStarted = true;
			ballBehaviour.setMovementDirection (new Vector2 (ballSpeed, 0));
		}
		downButtonPress = true;
	}

	public void onDownButtonRelease() {
		downButtonPress = false;
	}

	private void stopRacket() {
		racket.setDirection (Vector2.zero);
	}

	private void setScore(int leftPlayerScore, int rightPlayerScore) {
		scoreText.text = leftPlayerScore.ToString () + " - " + rightPlayerScore.ToString ();
	}
		
}
