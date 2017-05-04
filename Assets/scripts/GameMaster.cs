using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public PlayerRacket racket;
	public HardBotRacket bot;
	public float RacketSpeed;
	public BallBehaviour ballBehaviour;
	public CameraShake cameraShake;

	public Health playerOneHealth;
	public Health playerTwoHealth;

	public GameObject gameOverScreen;

	private Text screenText;

	private int ballSpeed;
	private bool hasGameStarted = false;
	private bool isPaused = false;

	void Start() {
		ballSpeed = ballBehaviour.ballSpeed;
		initialize ();
		screenText = gameOverScreen.GetComponentInChildren<Text> ();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			if (!isPaused) { // if game is not yet paused, ESC will pause it
				isPaused = true;
				pauseGame();
			} else { // if game is paused and ESC is pressed, it's the second press. QUIT
				Application.Quit();
			}
		}
	}

	public void onLeftPlayerScore() {
		playerTwoHealth.setHealth (playerTwoHealth.getHealth() - 10);
		if (playerTwoHealth.getHealth () <= 0f) {
			showOverlayWithText ("You won!");
			ballBehaviour.setMovementDirection (Vector2.zero);
		}
	}

	public void onRightPlayerScore() {
		shakeScreen ();
		playerOneHealth.setHealth (playerOneHealth.getHealth() - 10);
		if (playerOneHealth.getHealth () <= 0f) {
			showOverlayWithText ("Game Over");
			ballBehaviour.setMovementDirection (Vector2.zero);
		}

	}

	public Vector2 getBallPosition() {
		return ballBehaviour.getBallPosition();
	}

	public Vector2 getBallDirection() {
		return ballBehaviour.getBallDirection();
	}

	public void onAnalogPress(Vector2 analogPosition) {
		moveBallIfGameStarted ();
		racket.setMovementDirection (analogPosition * RacketSpeed);
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

	private void showOverlayWithText(string text) {
		gameOverScreen.SetActive (true);
		screenText.text = text;
	}
		
	private void stopRacket() {
		racket.setMovementDirection (Vector2.zero);
	}

	private void moveBallIfGameStarted() {
		if (!hasGameStarted) {
			hasGameStarted = true;
			ballBehaviour.setMovementDirection (new Vector2 (ballSpeed, 0));
		}
	}

	private void shakeScreen() {
		cameraShake.shakeDuration = 0.2f;
	}

	private void initialize() {
		hasGameStarted = false;
		playerOneHealth.setHealth (100);
		playerTwoHealth.setHealth (100);
		gameOverScreen.SetActive (false);
		ballBehaviour.resetBallPosition ();
		racket.resetRacketPosition ();
		bot.resetRacketPosition ();
	}

	private void pauseGame() {
		Time.timeScale = 0;
		showOverlayWithText ("PAUSED");
	}
		
}
