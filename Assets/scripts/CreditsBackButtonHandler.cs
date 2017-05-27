using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBackButtonHandler : MonoBehaviour {

	public StartEasyGame startEasyGame;

	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			startEasyGame.openMainMenu ();
		}
	}
}
