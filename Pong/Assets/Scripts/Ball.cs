using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 5f;

	void Start () {
        Invoke("assignVelocity", 1);
    }

    void assignVelocity () {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;    //remember that Random.Range excludes the second argument from the choice, so there will only be returned 0 or 1 values.
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * xDirection, speed * yDirection, 0f);
    }

    void OnTriggerEnter(Collider other) {
    	/*if (other.tag == "OffScene") {
    		other.transform.
    	}*/
    }
}
