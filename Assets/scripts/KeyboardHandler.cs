using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

	private static string DOWN_AXIS = "Down";
	private static string UP_AXIS = "Up";

	public GameMaster GameMaster;

	void Update() {
		if (Input.GetButtonDown (DOWN_AXIS)) {
			GameMaster.onDownButtonPress ();
		} else if (Input.GetButtonUp (DOWN_AXIS)) {
			GameMaster.onDownButtonRelease ();
		}

		if (Input.GetButtonDown (UP_AXIS)) {
			GameMaster.onUpButtonPress ();
		} else if (Input.GetButtonUp (UP_AXIS)) {
			GameMaster.onUpButtonRelease ();
		}
	}

}
