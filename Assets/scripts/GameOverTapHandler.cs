using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameOverTapHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public GameMaster gameMaster;

	public virtual void OnPointerUp(PointerEventData eventData) {
		gameMaster.onRestartGame ();
	}

	public virtual void OnPointerDown(PointerEventData eventData) {
//		gameMaster.onRestartGame ();
	}

}
