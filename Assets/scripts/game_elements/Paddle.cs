using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Paddle : MonoBehaviour {

	public GameMaster gameMaster;
	public float maxHealth;
	public float paddleSpeed;
	public HealthBar healthBar;

	protected Rigidbody2D paddle;

	private float currentHealth;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		paddle = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHealth = maxHealth;
	}

	public abstract void resetPaddlePosition();


	public void setMovementDirection(Vector2 direction) {
		paddle.velocity = direction * paddleSpeed;
	}
 
	public void setPaddleSpeed (float speed) {
		paddleSpeed = speed;
	}

	public void setHealth(float health) {
		if (health >= 0 && health <= maxHealth) {
			currentHealth = health;
		} else if (health < 0) {
			currentHealth = 0;
		} else {
			currentHealth = maxHealth;
		}
		healthBar.updateHealthDisplay (currentHealth, maxHealth);
	}

	public float getHealth () {
		return currentHealth;
	}

	public float getMaxHealth () {
		return maxHealth;
	}

	public void activateBoostMode() {
		spriteRenderer.color = new Color (255, 0, 0);
		paddleSpeed = paddleSpeed * 2;
	}

	public void deactivateBoostMode() {
		spriteRenderer.color = new Color (255, 255, 255);
		paddleSpeed = paddleSpeed / 2;
	}

}
