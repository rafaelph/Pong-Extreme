﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public Paddle player;
	public HardBotPaddle bot;
	public Ball ball;
	public CameraShake cameraShake;
	public Text levelText;

	public GameObject gameOverScreen;

	private Text screenText;

	private int ballSpeed;
	private bool hasGameStarted = false;
	private bool isPaused = false;
	private bool playerBoostMode = false;
	private int gameLevel = 1;

	void Start() {
		ballSpeed = ball.ballSpeed;
		initialize ();
		screenText = gameOverScreen.GetComponentInChildren<Text> ();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			if (!isPaused) {
				isPaused = true;
				pauseGame();
			} else {
				Application.Quit();
			}
		}
	}

	public void onLeftPlayerScore() {
		float botHealth = bot.getHealth ();
		bot.setHealth (botHealth - 10);
		if (botHealth <= 0f) {
			showOverlayWithText ("You won!");
			ball.setMovementDirection (Vector2.zero);
			gameLevel++;
		}
	}

	public void onRightPlayerScore() {
		shakeScreen ();
		float playerHealth = player.getHealth();
		player.setHealth (playerHealth - 10);
		if (playerHealth <= 0f) {
			showOverlayWithText ("Game Over");
			ball.setMovementDirection (Vector2.zero);
		}

	}

	public Vector2 getBallPosition() {
		return ball.getBallPosition();
	}

	public Vector2 getBallDirection() {
		return ball.getBallDirection();
	}

	public void onAnalogPress(Vector2 analogPosition) {
		moveBallIfGameStarted ();
		player.setMovementDirection (analogPosition);
	}

	public void onRestartGame() {
		if (isPaused) {
			isPaused = false;
			gameOverScreen.SetActive (false);
			Time.timeScale = 1;
		} else {
			initialize ();
		}
	}

	public string getPlayerPaddleName() {
		return player.name;
	}

	public string getBotPaddleName() {
		return bot.name;
	}

	public void activateBoostMode() {
		playerBoostMode = true;
		player.activateBoostMode ();
	}

	public void deactivateBoostMode() {
		playerBoostMode = false;
		player.deactivateBoostMode ();
	}

	public bool isPlayerBoostMode() {
		return playerBoostMode;
	}

	private void showOverlayWithText(string text) {
		gameOverScreen.SetActive (true);
		screenText.text = text;
	}
		
	private void stopPlayerPaddle() {
		player.setMovementDirection (Vector2.zero);
	}

	private void moveBallIfGameStarted() {
		if (!hasGameStarted) {
			hasGameStarted = true;
			ball.setMovementDirection (new Vector2 (ballSpeed, 0));
		}
	}

	private void shakeScreen() {
		cameraShake.shakeDuration = 0.2f;
	}

	private void initialize() {
		hasGameStarted = false;
		gameOverScreen.SetActive (false);
		player.setHealth (player.getMaxHealth ());
		ball.deactivateFireEffect ();
		bot.setHealth (bot.getMaxHealth ());
		ball.resetBallPosition ();
		player.resetPaddlePosition ();
		bot.resetPaddlePosition ();
		bot.chanceToActAccordingly = gameLevel * 10;
		levelText.text = "Level " + gameLevel.ToString ();
	}

	private void pauseGame() {
		Time.timeScale = 0;
		showOverlayWithText ("PAUSED");
	}
		
}
