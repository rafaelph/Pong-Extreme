using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRepository {

	public int getMaxScore() {
		return PlayerPrefs.GetInt ("MAX_SCORE", 0);
	}

	public void setMaxScore(int maxScore) {
		PlayerPrefs.SetInt ("MAX_SCORE", maxScore);
		PlayerPrefs.Save ();
	}

}
