 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private RectTransform healthValueSprite;

	void Awake() {
		healthValueSprite = GetComponentsInChildren<RectTransform> ()[1];
	}	

	public void updateHealthDisplay(float newHealth, float maxHealth) {
		if (newHealth >= 0 && newHealth <= maxHealth) {
			healthValueSprite.transform.localScale = new Vector3 (newHealth / maxHealth, healthValueSprite.transform.localScale.y);
		} else {
			throw new UnityException ("new health should be between 0 and maxHealth");
		}
	}
}
