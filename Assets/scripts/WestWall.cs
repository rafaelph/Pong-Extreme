using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestWall : MonoBehaviour {

	public GameMaster gameMaster;

	void OnCollisionEnter2D (Collision2D collider) {
		GameObject colliderObject = collider.gameObject;
		if (collider.gameObject.CompareTag ("ball")) {
			gameMaster.onRightPlayerScore ();
		} 
	}
}
