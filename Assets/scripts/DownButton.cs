using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameMaster gameMaster;

	public void OnPointerDown (PointerEventData ignore) {
		gameMaster.onDownButtonPress ();
	}

	public void OnPointerUp (PointerEventData ignore) {
		gameMaster.onDownButtonRelease ();
	}
}
