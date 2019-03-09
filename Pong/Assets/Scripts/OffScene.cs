using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScene : MonoBehaviour {
    public Bumper goalOwner;
    public GameController gameController;
	
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Ball") {
            Destroy(other.gameObject);
			gameController.NewRound();
			goalOwner.score++;
        }
	}
}
