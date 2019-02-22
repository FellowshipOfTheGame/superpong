using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public GameController gameController;
    public float speed;

	void Start () {
        Invoke("assignVelocity", 1);
    }

    void Update () {
    	if (gameController.gameOver)
    		Destroy(gameObject);
       // Debug.Log("velocidade da bola: "+GetComponent<Rigidbody>().velocity);
    }

    void assignVelocity () {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;    //remember that Random.Range excludes the second argument from the choice, so there will only be returned 0 or 1 values.
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * xDirection, speed * yDirection, 0f);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "PowerUp") {
            GameObject powerUpObject = collider.gameObject;
            powerUpObject.GetComponent<PowerUp>().Execute(); // execute o powerup
            powerUpObject.GetComponent<Renderer>().enabled = false; // não exiba o powerup na cena
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
