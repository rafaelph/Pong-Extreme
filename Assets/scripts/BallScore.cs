using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour {

	public GameMaster gameMaster;


	void OnCollisionEnter2D (Collision2D collider) {
		GameObject colliderObject = collider.gameObject;
		if (collider.gameObject.CompareTag ("right_wall")) {
			gameMaster.onLeftPlayerScore ();
		} 

		if (collider.gameObject.CompareTag ("left_wall")) {
			gameMaster.onRightPlayerScore ();
		}
	}
		
}
