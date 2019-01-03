using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScene : MonoBehaviour {

    public GameObject ballPrefab;
    public Bumper goalOwner;
    public GameController gameController;
	
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Ball") {
            Destroy(other.gameObject);
            if (!gameController.gameOver)
            	Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            goalOwner.score++;
        }
	}
}
