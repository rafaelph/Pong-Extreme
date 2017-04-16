using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

	private int playerOneScore = 0;
	private int playerTwoScore = 0;

	private static ScoreManager instance = new ScoreManager ();

	private ScoreManager () {
	}

	public static ScoreManager getInstance() {
		return instance;
	}

	public void clearScores() {
		playerOneScore = 0;
		playerTwoScore = 0;
	}

	public int getPlayerOneScore() {
		return playerOneScore;
	}

	public int getPlayerTwoScore() {
		return playerTwoScore;
	}

	public void increasePlayerOneScore() {
		playerOneScore += 1;
	}

	public void increasePlayerTwoScore() {
		playerTwoScore += 1;
	}
}
