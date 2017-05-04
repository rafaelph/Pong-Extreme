﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public int ballSpeed;

	private Rigidbody2D ball;
	private ParticleSystem ParticleSystem;

	void Awake() {
		ball = GetComponent<Rigidbody2D> ();
		ParticleSystem = GetComponentInChildren<ParticleSystem> ();
	}

	void Start () {

	}

	void OnCollisionEnter2D (Collision2D collider) {
		GameObject colliderObject = collider.gameObject;
		if (collider.gameObject.CompareTag ("left_racket")) {
			float yMagnitude = getYMagnitude (transform.position, colliderObject.transform.position, collider.collider.bounds.size.y);

			float direction = 1;
			if (colliderObject.transform.position.x > transform.position.x) {
				direction = -1;
			}
			Vector2 newDirection = new Vector2 (direction, yMagnitude).normalized;
			ball.velocity = newDirection * ballSpeed;
			activateParticle ();
		} 

		if (collider.gameObject.CompareTag ("right_racket")) {
			float yMagnitude = getYMagnitude (transform.position, colliderObject.transform.position, collider.collider.bounds.size.y);
			float direction = -1;
			if (colliderObject.transform.position.x < transform.position.x) {
				direction = 1;
			}
			Vector2 newDirection = new Vector2 (direction, yMagnitude).normalized;
			ball.velocity = newDirection * ballSpeed;
			activateParticle ();
		}
	}

	public void setMovementDirection(Vector2 direction) {
		ball.velocity = direction;
	}

	public Vector2 getBallPosition() {
		return ball.position;
	}

	public Vector2 getBallDirection() {
		return ball.velocity;
	}

	public void resetBallPosition() {
		ball.transform.position = Vector2.zero;
	}

	private void activateParticle() {
		ParticleSystem.Play ();
	}

	private float getYMagnitude(Vector2 ballVector, Vector2 racketVector, float racketHeight) {
		return (ballVector.y - racketVector.y) / racketHeight;
	}
}
