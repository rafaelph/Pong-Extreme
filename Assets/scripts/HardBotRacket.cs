using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBotRacket : MonoBehaviour {

	public GameMaster GameMaster;

	private Rigidbody2D racket;
	private float racketSpeed = 30;
	private float thresholdFactor = 1.8f;
	private float racketHeight;

	void Start () {
		racket = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		Vector2 ballPosition = GameMaster.getBallPosition ();
		float ballYPosition = ballPosition.y;
		float yDifference = ballYPosition - racket.position.y;

		if ((ballPosition.x < racket.position.x)) {
			if (yDifference > thresholdFactor) {
				racket.velocity = new Vector2 (0, racketSpeed);
			} else if (yDifference < -thresholdFactor) {
				racket.velocity = new Vector2 (0, -racketSpeed);
			} else {
				racket.velocity = Vector2.zero;
			}
		} else {
			if (yDifference > thresholdFactor) {
				racket.velocity = new Vector2 (0, -racketSpeed);
			} else if (yDifference < -thresholdFactor) {
				racket.velocity = new Vector2 (0, racketSpeed);
			} else {
				racket.velocity = Vector2.zero;
			}
		}
	}
}
