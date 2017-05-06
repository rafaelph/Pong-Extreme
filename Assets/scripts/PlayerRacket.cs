using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRacket : Player {

	override
	public void resetRacketPosition() {
		racket.transform.position = new Vector2 (-26, 0);
	}
}
