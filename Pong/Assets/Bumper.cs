using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public bool isBumperOne;
    public float translationSpeed = 5f;
    public float rotationSpeed = 500f;
    private Vector3 movement;

	void Update () {
		if (isBumperOne)
        {
            transform.Translate(0f, Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime, 0f);
            transform.Rotate(0f, 0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0f, Input.GetAxis("Vertical2") * translationSpeed * Time.deltaTime, 0f);
            transform.Rotate(0f, 0f, Input.GetAxis("Horizontal2") * rotationSpeed * Time.deltaTime);
        }
	}
}
