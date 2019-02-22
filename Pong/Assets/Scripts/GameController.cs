using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public Bumper left, right;
	public int maxScore;
	[HideInInspector]
	public bool gameOver;
	public GameObject ballPrefab;
	public float powerUpSpawnTime = 0;
	public Vector3[] spawnPoints;
	public GameObject genericPowerUp;
	public float powerUpTimer;
	private float timer;
	public GameObject[] powerUp;
	public bool powerUpDisabled;

	void Awake () {
		gameOver = false;
		InvokeRepeating("spawnPowerUp", powerUpSpawnTime, powerUpSpawnTime);
		timer = powerUpTimer;
		powerUpDisabled = true;
	}

	void Update () {
		if (left.score == maxScore || right.score == maxScore) {
			Debug.Log("O jogador " + (left.score == maxScore ? "1" : "2") + " é o vencedor!");
			gameOver = true;
			Invoke("WinPrompt", 2);
			// TODO sinalizar o fim de jogo globalmente
		}

		
	}

	void FixedUpdate () {
		timer--;
		if (timer == 0) {
			//spawnPowerUp();
			timer = powerUpTimer;
		}
	}

	void WinPrompt () {
		// TODO tela de vitoria UI
		SceneManager.LoadScene("MainMenu");
	}

	public void newRound () {
		if (!gameOver) {
			Invoke("createBall", 3);
			left.resetPosition();
			right.resetPosition();
		}
		
	}

	void createBall () {
		Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
	}

	void spawnPowerUp() {
		if (powerUpDisabled) {
			int powerUpIndex = Random.Range(0, powerUp.Length);
			int spawnPointIndex = Random.Range(0, spawnPoints.Length);
			Instantiate(powerUp[powerUpIndex], spawnPoints[spawnPointIndex], Quaternion.identity);
		}
	}
}
