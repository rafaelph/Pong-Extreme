using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotRacket : MonoBehaviour {

	public GameMaster GameMaster;

	private Rigidbody2D racket;
	private float racketSpeed = 30;
	private float thresholdFactor = 1f;
	private float racketHeight;

	void Start () {
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
		return GameMaster.getBallDirection().x < 0;
	}

	private bool isBallNotReactable() {
		return GameMaster.getBallPosition ().x < 0;
	}

	private void stopRacket () {
		racket.velocity = Vector2.zero;
	}

	private void attemptToBlockTheBall() {
		float ballAndRacketYDifference = Mathf.FloorToInt(GameMaster.getBallPosition ().y - racket.position.y);
		if (ballAndRacketYDifference > thresholdFactor) {
			racket.velocity = new Vector2 (0, racketSpeed);
		} else if (ballAndRacketYDifference < -thresholdFactor) {
			racket.velocity = new Vector2 (0, -racketSpeed);
		} else {
			racket.velocity = Vector2.zero;
		}
	}

	private bool isBallRightOfRacket() {
		return GameMaster.getBallPosition().x > racket.position.x;
	}
}
