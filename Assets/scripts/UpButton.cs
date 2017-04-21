using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameMaster gameMaster;

	public void OnPointerDown (PointerEventData ignore) {
		gameMaster.onUpButtonPress ();
	}

	public void OnPointerUp (PointerEventData ignore) {
		gameMaster.onUpButtonRelease ();
	}
}
