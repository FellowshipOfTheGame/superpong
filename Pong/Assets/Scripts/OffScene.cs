using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScene : MonoBehaviour {

    public GameObject ballPrefab;
	
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Ball") {
            Destroy(other.gameObject);
            Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
}
