using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public GameController gameController;
    public float speed;
	public float impulseSpeed;
	public float minRebounceAngle;
	public float maxRebounceAngle;
	public Rigidbody ballRb;

	void Start () {
        Invoke("assignVelocity", 1);
    }

    void Update () {
    	if (gameController.gameOver)
    		Destroy(gameObject);
    }

    void assignVelocity () {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;    //remember that Random.Range excludes the second argument from the choice, so there will only be returned 0 or 1 values.
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

		ballRb.velocity = new Vector3(speed*xDirection, speed*yDirection, 0f);
    }
		
	void OnCollisionEnter(Collision col) {
		//add Force, instead of changing the velocity
		if (col.gameObject.tag == "Bumper") {
			float minAngle = minRebounceAngle*(Mathf.PI)/180f;	//in radians
			float maxAngle = maxRebounceAngle*(Mathf.PI)/180f;	//in radians

			float ballDist = transform.position.y - col.gameObject.transform.position.y;
			float bumpRadius = 1.9f;
			float percent = Mathf.Abs(ballDist/bumpRadius);

			if (ballDist == 0) {
				int randY = Random.Range (0, 2) == 0 ? -1 : 1;

				if (col.gameObject.name == "Bumper1") {
					ballRb.AddForce(impulseSpeed*percent, impulseSpeed*percent*randY*(Mathf.Tan(minAngle)), 0f, ForceMode.Impulse);
				} else {
					ballRb.AddForce(-impulseSpeed*percent, impulseSpeed*percent*randY*(Mathf.Tan(minAngle)), 0f, ForceMode.Impulse);
				}
			} else {
				float angleToAdd = (maxAngle-minAngle)*(percent);

				if (col.gameObject.name == "Bumper1") {
					ballRb.AddForce(impulseSpeed*percent, impulseSpeed*percent*(ballDist/Mathf.Abs(ballDist))*(Mathf.Tan(minAngle + angleToAdd)), 0f, ForceMode.Impulse);
				} else {
					ballRb.AddForce(-impulseSpeed*percent, impulseSpeed*percent*(ballDist/Mathf.Abs(ballDist))*(Mathf.Tan(minAngle + angleToAdd)), 0f, ForceMode.Impulse);
				}
			}
		}
	}

    //void OnTriggerEnter(Collider other) {
    	/*if (other.tag == "OffScene") {
    		other.transform.
    	}*/
    //}
}
