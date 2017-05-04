using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private float currentHealth = 100f;
	private float maxHealth = 100f;

	private RectTransform healthValueSprite;

	void Start() {
		healthValueSprite = GetComponentsInChildren<RectTransform> ()[1];
	}

	public void decreaseHealth() {
		currentHealth = currentHealth - 10f;
		if (currentHealth >= 0) {
			healthValueSprite.transform.localScale = new Vector3 (currentHealth/maxHealth, healthValueSprite.transform.localScale.y);
		}
	}

	public float getHealth() {
		return currentHealth;
	}
}
