using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

	public int ballSpeed = 30;

	private Rigidbody2D ball;

	void Start () {
		ball = GetComponent<Rigidbody2D> ();
	}

	public void startMoving () {
		ball.velocity = new Vector3 (ballSpeed, 0);
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
		} 

		if (collider.gameObject.CompareTag ("right_racket")) {
			float yMagnitude = getYMagnitude (transform.position, colliderObject.transform.position, collider.collider.bounds.size.y);
			float direction = -1;
			if (colliderObject.transform.position.x < transform.position.x) {
				direction = 1;
			}
			Vector2 newDirection = new Vector2 (direction, yMagnitude).normalized;
			ball.velocity = newDirection * ballSpeed;
		}
	}

	float getYMagnitude(Vector2 ballVector, Vector2 racketVector, float racketHeight) {
		return (ballVector.y - racketVector.y) / racketHeight;
	}
}
