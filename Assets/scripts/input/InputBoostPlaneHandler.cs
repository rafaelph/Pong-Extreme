using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputBoostPlaneHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	public GameMaster gameMaster;

	public virtual void OnPointerDown(PointerEventData eventData) {
		gameMaster.activateBoostMode ();
	}

	public virtual void OnPointerUp(PointerEventData eventData) {
		gameMaster.deactivateBoostMode ();
	}

	public virtual void OnDrag(PointerEventData eventData) {

	}

}
