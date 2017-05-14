using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotPaddle : Paddle {

	private float thresholdFactor = 1f;
	public int chanceToActAccordingly;

	private bool hasChanceGeneratorRan = false;
	private bool isSuccessful = false;

	void FixedUpdate () {
		if (isBallRightOfPaddle ()) {
			returnToCenterPosition ();
			hasChanceGeneratorRan = false;
			isSuccessful = false;
		} else if (isBallGoingToTheLeft () || isBallNotReactable ()) {
			stopPaddle ();
			hasChanceGeneratorRan = false;
			isSuccessful = false;
		} else {
			if (hasChanceGeneratorRan) {
				if (isSuccessful) {
					attemptToBlockTheBall ();
				}
			} else {
				if (ChanceGenerator.IsSuccessful (chanceToActAccordingly)) {
					isSuccessful = true;
				} else {
					isSuccessful = false;
				}
				hasChanceGeneratorRan = true;
			}
		}
	}

	override
	public void resetPaddlePosition() {
		paddle.transform.position = new Vector2 (26, 0);
	}

	private void returnToCenterPosition () {
		float paddlePosition = Mathf.FloorToInt (paddle.position.y);
		if (paddlePosition < 0) {
			setMovementDirection (Vector2.up);
		} else if (paddlePosition > 0) {
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

	private void stopPaddle () {
		paddle.velocity = Vector2.zero;
	}

	private void attemptToBlockTheBall() {
		float ballAndPaddleYDifference = Mathf.FloorToInt(gameMaster.getBallPosition ().y - paddle.position.y);
		if (ballAndPaddleYDifference > thresholdFactor) {
			paddle.velocity = new Vector2 (0, paddleSpeed);
		} else if (ballAndPaddleYDifference < -thresholdFactor) {
			paddle.velocity = new Vector2 (0, -paddleSpeed);
		} else {
			paddle.velocity = Vector2.zero;
		}
	}

	private bool isBallRightOfPaddle() {
		return gameMaster.getBallPosition().x > paddle.position.x;
	}
}
