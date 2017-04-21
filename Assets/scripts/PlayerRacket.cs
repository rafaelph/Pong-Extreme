using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : MonoBehaviour {

	private Rigidbody2D racket;

	void Start () {
		racket = GetComponent<Rigidbody2D> ();
	}
	
	public void setDirection(Vector2 direction) {
		racket.velocity = direction;
	}
}
