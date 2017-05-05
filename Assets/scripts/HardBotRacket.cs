using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotRacket : MonoBehaviour {

	public GameMaster gameMaster;

	private Rigidbody2D racket;
	private float racketSpeed = 30;
	private float thresholdFactor = 1f;
	private float racketHeight;

	void Awake () {
		racket = GetComponent<Rigidbody2D> ();
}
	
	void FixedUpdate () {
		if (isBallRightOfRacket ()) {
			returnToCenterPosition ();
		} else if (isBallGoingToTheLeft () || isBallNotReactable ()) {
			stopRacket ();
		} else {
			attemptToBlockTheBall ();
		}
	}

	public void resetRacketPosition() {
		racket.transform.position = new Vector2 (26, 0);
	}

	private void returnToCenterPosition () {
		float racketYPosition = Mathf.FloorToInt (racket.position.y);
		if (racketYPosition < 0) {
			racket.velocity = new Vector2 (0, racketSpeed);
		} else if (racketYPosition > 0) {
			racket.velocity = new Vector2 (0, -racketSpeed);
		} else {
			racket.velocity = Vector2.zero;
		}
	}

	private bool isBallGoingToTheLeft() {
		return gameMaster.getBallDirection().x < 0;
	}

	private bool isBallNotReactable() {
		return gameMaster.getBallPosition ().x < 0;
	}

	private void stopRacket () {
		racket.velocity = Vector2.zero;
	}

	private void attemptToBlockTheBall() {
		float ballAndRacketYDifference = Mathf.FloorToInt(gameMaster.getBallPosition ().y - racket.position.y);
		if (ballAndRacketYDifference > thresholdFactor) {
			racket.velocity = new Vector2 (0, racketSpeed);
		} else if (ballAndRacketYDifference < -thresholdFactor) {
			racket.velocity = new Vector2 (0, -racketSpeed);
		} else {
			racket.velocity = Vector2.zero;
		}
	}

	private bool isBallRightOfRacket() {
		return gameMaster.getBallPosition().x > racket.position.x;
	}
}
