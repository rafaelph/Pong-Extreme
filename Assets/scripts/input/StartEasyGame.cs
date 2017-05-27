using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartEasyGame : MonoBehaviour {

	private Text startText;

	public GameObject loadingMask;

	public void openNextScene() {
		SceneManager.LoadScene ("Main Scene");
		showLoadingScreen ();
	}

	public void openCreditsScene() {
		SceneManager.LoadScene ("Credits Scene");
	}

	public void openMainMenu() {
		SceneManager.LoadScene ("Main Menu Scene");
	}

	private void showLoadingScreen() {
		loadingMask.SetActive (true);
	}


}
