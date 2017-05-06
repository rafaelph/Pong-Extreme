using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotRacket : Player {

	private float thresholdFactor = 1f;
	
	void FixedUpdate () {
		if (isBallRightOfRacket ()) {
			returnToCenterPosition ();
		} else if (isBallGoingToTheLeft () || isBallNotReactable ()) {
			stopRacket ();
		} else {
			attemptToBlockTheBall ();
		}
	}

	override
	public void resetRacketPosition() {
		racket.transform.position = new Vector2 (26, 0);
	}

	private void returnToCenterPosition () {
		float racketYPosition = Mathf.FloorToInt (racket.position.y);
		if (racketYPosition < 0) {
			setMovementDirection (Vector2.up);
		} else if (racketYPosition > 0) {
			setMovementDirection (Vector2.down);
		} else {
			setMovementDirection (Vector2.zero);
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
