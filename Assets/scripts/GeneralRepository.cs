using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRepository {
	private const string MAX_SCORE = "MAX_SCORE";
	private const string IS_MUTE = "IS_MUTE";

	public int getMaxScore() {
		return PlayerPrefs.GetInt (MAX_SCORE, 0);
	}

	public void setMaxScore(int maxScore) {
		PlayerPrefs.SetInt (MAX_SCORE, maxScore);
		PlayerPrefs.Save ();
	}

	public int getMuteStatus() {
		return PlayerPrefs.GetInt (IS_MUTE, 0);
	}

	public void enableMute() {
		PlayerPrefs.SetInt (IS_MUTE, 1);
		PlayerPrefs.Save ();
	}

	public void disableMute() {
		PlayerPrefs.SetInt (IS_MUTE, 0);
		PlayerPrefs.Save ();
	}

}
