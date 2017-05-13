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

	private void showLoadingScreen() {
		loadingMask.SetActive (true);
	}


}
