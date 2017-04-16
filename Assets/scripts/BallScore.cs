using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour {

	private ScoreManager scoreManager = ScoreManager.getInstance();

	public Text scoreText;

	void OnCollisionEnter2D (Collision2D collider) {
		GameObject colliderObject = collider.gameObject;
		if (collider.gameObject.CompareTag ("right_wall")) {
			scoreManager.increasePlayerOneScore ();
		} 

		if (collider.gameObject.CompareTag ("left_wall")) {
			scoreManager.increasePlayerTwoScore ();
		}

		updateScoreText ();
	}

	void updateScoreText() {
		scoreText.text = scoreManager.getPlayerOneScore().ToString () + " - " + scoreManager.getPlayerTwoScore().ToString ();
	}
}
