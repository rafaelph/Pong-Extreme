using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle {

	override
	public void resetPaddlePosition() {
		paddle.transform.position = new Vector2 (-26, 0);
	}
}
