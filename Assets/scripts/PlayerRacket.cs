using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour {

	private Rigidbody2D racket;

	void Awake () {
		racket = GetComponent<Rigidbody2D> ();
	}
	
	public void setMovementDirection(Vector2 direction) {
		racket.velocity = direction;
	}

	public void resetRacketPosition() {
		racket.transform.position = new Vector2 (-26, 0);
	}
}
