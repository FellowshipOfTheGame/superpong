using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject mainScreen;
	public GameObject playScreen;
	public GameObject instructionsScreen;
	public ScrollRect scrollView;
	public GameObject optionsScreen;

	public void StartGame() {
		SceneManager.LoadScene("Pong");
	}

	public void EnablePlayScreen() {
		mainScreen.SetActive(false);
		playScreen.SetActive(true);
	}

	public void EnableInstructions() {
		scrollView.verticalNormalizedPosition = 1f;
		mainScreen.SetActive(false);
		instructionsScreen.SetActive(true);
	}

	public void EnableOptions() {
		mainScreen.SetActive(false);
		optionsScreen.SetActive(true);
	}

	public void EnableMainScreen() {
		mainScreen.SetActive(true);
		playScreen.SetActive(false);
		instructionsScreen.SetActive(false);
		optionsScreen.SetActive(false);
	}

	public void Quit() {
		Application.Quit();
	}
}
