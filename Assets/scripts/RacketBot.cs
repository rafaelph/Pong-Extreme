using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketBot : MonoBehaviour {

	public Rigidbody2D ball;

	private Rigidbody2D racket;

	private float racketSpeed = 30;
	private float thresholdFactor = 1.8f;
	private float racketHeight;

	void Start () {
		racket = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float ballYPosition = ball.position.y;
		float racketYPosition = racket.position.y;

		float positionYDifference = ballYPosition - racketYPosition;
		if ((ball.position.x < racket.position.x)) {
			if (positionYDifference > thresholdFactor) {
				racket.velocity = new Vector2 (0, racketSpeed);
			} else if (positionYDifference < -thresholdFactor) {
				racket.velocity = new Vector2 (0, -racketSpeed);
			} else {
				racket.velocity = Vector2.zero;
			}
		} else {
			if (positionYDifference > thresholdFactor) {
				racket.velocity = new Vector2 (0, -racketSpeed);
			} else if (positionYDifference < -thresholdFactor) {
				racket.velocity = new Vector2 (0, racketSpeed);
			} else {
				racket.velocity = Vector2.zero;
			}
		}
	}
}
