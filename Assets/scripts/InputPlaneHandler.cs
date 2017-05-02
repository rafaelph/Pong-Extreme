using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputPlaneHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Vector2 previousTapPosition = Vector2.zero;
	private float threshold = 3.0f;

	public GameMaster gameMaster;

	public virtual void OnPointerDown(PointerEventData eventData) {
		previousTapPosition = Vector2.zero;
	}

	public virtual void OnPointerUp(PointerEventData eventData) {
		gameMaster.onAnalogPress (Vector2.zero);
	}

	public virtual void OnDrag(PointerEventData eventData) {
		Vector2 currentTapPosition = eventData.position;

		if (currentTapPosition.y - previousTapPosition.y > threshold) {
			gameMaster.onAnalogPress (Vector2.up);
		} else if (previousTapPosition.y - currentTapPosition.y > threshold) {
			gameMaster.onAnalogPress (Vector2.down);
		} else {
		}

		previousTapPosition = eventData.position;
	}
}
