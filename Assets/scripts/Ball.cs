using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball	 : MonoBehaviour {

	public GameMaster gameMaster;
	public int ballSpeed;

	private Rigidbody2D ball;
	private AudioSource audioSource;

	public ParticleSystem sparkEffect;
	public ParticleSystem fireEffect;
	public AudioClip ballImpactSound;

	void Awake() {
		ball = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.playOnAwake = false;
		audioSource.clip = ballImpactSound;
	}

	void OnCollisionEnter2D (Collision2D collider) {
		GameObject colliderObject = collider.gameObject;
		audioSource.Play ();
		activateSparkEffect ();
		if (collider.gameObject.name.Equals (gameMaster.getPlayerPaddleName ())) {
			float yMagnitude = getYMagnitude (transform.position, colliderObject.transform.position, collider.collider.bounds.size.y);

			float direction = 1;
			if (colliderObject.transform.position.x > transform.position.x) {
				direction = -1;
			}
			Vector2 newDirection = new Vector2 (direction, yMagnitude).normalized;
			if (gameMaster.isPlayerBoostMode ()) {
				ball.velocity = newDirection * ballSpeed * 2;
				activateFireEffect ();
			} else {
				ball.velocity = newDirection * ballSpeed;
			}

		} else if (collider.gameObject.name.Equals (gameMaster.getBotPaddleName ())) {
			float yMagnitude = getYMagnitude (transform.position, colliderObject.transform.position, collider.collider.bounds.size.y);
			float direction = -1;
			if (colliderObject.transform.position.x < transform.position.x) {
				direction = 1;
			}
			Vector2 newDirection = new Vector2 (direction, yMagnitude).normalized;
			ball.velocity = newDirection * ballSpeed;
			deactivateFireEffect ();
		} else if (collider.gameObject.CompareTag ("score_wall")) {
			ball.velocity = ball.velocity.normalized * ballSpeed;
			deactivateFireEffect ();
		}
	}

	public void setMovementDirection(Vector2 direction) {
		ball.velocity = direction;
	}

	public void updateCurrentBallSpeed(float ballSpeed) {
		ball.velocity = ball.velocity.normalized * ballSpeed;
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

	public void activateSparkEffect() {
		sparkEffect.Play ();
	}

	public void activateFireEffect() {
		fireEffect.Play ();
	}

	public void deactivateFireEffect() {
		fireEffect.Stop ();
	}

	private float getYMagnitude(Vector2 ballVector, Vector2 paddleVector, float paddleHeight) {
		return (ballVector.y - paddleVector.y) / paddleHeight;
	}
}
