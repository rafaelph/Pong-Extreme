using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {

	public int Speed = 30;
	public string axis = "Vertical";

	void FixedUpdate () {
		float direction = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Speed * direction);
	}
}
