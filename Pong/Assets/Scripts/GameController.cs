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
	public Vector3[] spawnPoints;
	public float powerUpTimer;
	private float timer;
	public GameObject[] powerUp;
	public bool powerUpDisabled;
	public bool waitNewRound;
	private float newRoundTimer;
	public int timeToReset;

	void Awake () {
		gameOver = false;
		//InvokeRepeating("spawnPowerUp", powerUpSpawnTime, powerUpSpawnTime);
		timer = 0;
		newRoundTimer = 0;
		powerUpDisabled = true;
		waitNewRound = false;
	}

	void Update () {
		if (left.score == maxScore || right.score == maxScore) {
			Debug.Log("O jogador " + (left.score == maxScore ? "1" : "2") + " é o vencedor!");
			gameOver = true;
			Invoke("WinPrompt", timeToReset);
			// TODO sinalizar o fim de jogo globalmente
		}

		
	}

	void FixedUpdate () {
		//Debug.Log ("Não há power ups na cena: "+powerUpDisabled);
		if (waitNewRound) {
			//Debug.Log("Waiting for new round");
			newRoundTimer += Time.fixedDeltaTime;
			if (newRoundTimer > timeToReset)
				waitNewRound = false;
		}

		//Debug.Log("Time to spawn powerup: "+timer);
		if (powerUpDisabled) timer += Time.fixedDeltaTime;
		else if (!powerUpDisabled && waitNewRound) timer = 0;

		if (timer > Random.Range(0.5f, powerUpTimer)) {
			spawnPowerUp();
			timer = 0;
		}
	}

	void WinPrompt () {
		// TODO tela de vitoria UI
		SceneManager.LoadScene("MainMenu");
	}

	public void newRound () {
		waitNewRound = true;
		if (!gameOver) {
			Invoke("createBall", timeToReset);
			left.resetPosition();
			right.resetPosition();
			Destroy(GameObject.FindWithTag("PowerUp")); // destruir o power up que estiver na cena
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
