using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public GameController gameController;
    public float speed;
    private Rigidbody rb;

	void Start () {
        Invoke("assignVelocity", 1);
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
    	if (gameController.gameOver)
    		Destroy(gameObject);
        if (gameController.waitNewRound)
            Invoke("assignVelocity", 1);
        //Debug.Log("velocidade da bola: "+GetComponent<Rigidbody>().velocity.magnitude);
    }

    void assignVelocity () {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;    //remember that Random.Range excludes the second argument from the choice, so there will only be returned 0 or 1 values.
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector3(speed * xDirection, speed * yDirection, 0f);
        Debug.Log("Alteração na velocidade!");
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "PowerUp") {
            GameObject powerUpObject = collider.gameObject;
            Renderer powerUpRenderer = powerUpObject.GetComponent<Renderer>();

            if (powerUpRenderer.enabled) {
                Debug.Log("Colidiu com powerup");
                powerUpObject.GetComponent<PowerUp>().Execute(); // execute o powerup
                Debug.Log("O powerup atingido foi desabilitado");
                powerUpRenderer.enabled = false; // não exiba o powerup na cena
            }
        }
    }
/*
    void OnColliderEnter(Collider collider) {
        if (collider.tag == "Bumper") {
            float modifier = collider.gameObject.GetComponent<Bumper>().hitFactor(ball: gameObject);
            if (modifier < -0.2) yModifier = 
        }
    }
*/
}
