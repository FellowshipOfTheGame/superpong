using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public Bumper left, right;
	public int maxScore;
	public bool gameOver;

	void Awake () {
		gameOver = false;
	}

	void Update () {
		if (left.score == maxScore || right.score == maxScore) {
			Debug.Log("O jogador " + (left.score == maxScore ? "1" : "2") + " é o vencedor!");
			gameOver = true;
			Invoke("WinPrompt", 3);
			// TODO sinalizar o fim de jogo globalmente
		}
	}

	void WinPrompt () {
		SceneManager.LoadScene("MainMenu");
	}
}
