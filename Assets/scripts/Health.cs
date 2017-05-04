using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private float currentHealth = 100f;
	private float maxHealth = 100f;

	private RectTransform healthValueSprite;

	void Awake() {
		healthValueSprite = GetComponentsInChildren<RectTransform> ()[1];
	}

	void Start() {
	}

	public void setHealth(float health) {
		if (health >= 0 && health <= maxHealth) {
			currentHealth = health;
		} else if (health < 0) {
			currentHealth = 0;
		} else {
			currentHealth = maxHealth;
		}
		updateHealthDisplay ();
	}

	public float getHealth() {
		return currentHealth;
	}

	private void updateHealthDisplay() {
		if (currentHealth >= 0) {
			healthValueSprite.transform.localScale = new Vector3 (currentHealth/maxHealth, healthValueSprite.transform.localScale.y);
		}
	}
}
