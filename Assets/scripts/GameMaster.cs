using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public PlayerRacket racket;
	public float RacketSpeed;
	public BallBehaviour ballBehaviour;
	public CameraShake cameraShake;

	public Health playerOneHealth;
	public Health playerTwoHealth;

	public GameObject gameOverScreen;

	private int ballSpeed;
	private bool hasGameStarted = false;

	void Start() {
		ballSpeed = ballBehaviour.ballSpeed;
	}

	void Update() {

	}

	public void onLeftPlayerScore() {
		playerTwoHealth.decreaseHealth ();
	}

	public void onRightPlayerScore() {
		shakeScreen ();
		playerOneHealth.decreaseHealth ();
		if (playerOneHealth.getHealth () <= 0f) {
			showGameOverScreen ();
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

	private void showGameOverScreen() {
		gameOverScreen.SetActive (true);
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
		
}
