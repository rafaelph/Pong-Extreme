using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	public GameMaster gameMaster;
	public float maxHealth;
	public float racketSpeed;
	public HealthBar healthBar;

	protected Rigidbody2D racket;

	private float currentHealth;

	void Awake() {
		racket = GetComponent<Rigidbody2D> ();
		currentHealth = maxHealth;
	}

	public abstract void resetRacketPosition();


	public void setMovementDirection(Vector2 direction) {
		racket.velocity = direction * racketSpeed;
	}
 
	public void setRacketSpeed (float speed) {
		racketSpeed = speed;
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
		gameMaster.activateBoostMode ();
	}

}
