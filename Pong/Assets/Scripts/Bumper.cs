using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bumper : MonoBehaviour {
    [HideInInspector] public int score;
    public Text scoreLabel;
    public bool isBumperOne;
    public float translationSpeed = 5f;
    public float rotationSpeed = 500f;
    public GameObject controller;
    private Vector3 previousMousePosition;
    private Vector3 mousePosition;
    private Vector3 newPosition;
    private Vector3 initialPosition;
    private Vector3 initialControllerPosition;

    void Awake() {
        previousMousePosition = new Vector3(0,0,0);
        mousePosition = new Vector3(0,0,0);
        newPosition = new Vector3(0,0,0);
        score = 0;

        initialPosition = transform.position;
        initialControllerPosition = controller.transform.position;
    }

	void Update () {
		if (isBumperOne) {
            transform.parent.Translate(0f, Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime, 0f);
        } else {
            transform.parent.Translate(0f, Input.GetAxis("Vertical2") * translationSpeed * Time.deltaTime, 0f);
        }

        //Debug.Log((isBumperOne ? "One: " : "Zero: ") + score);
        scoreLabel.text = score.ToString();
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Ball") {
			GetComponent<AudioSource>().Play();
		}
	}

    public void OnPointerBeginDrag() {
        previousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerDrag() {
        mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); // get mouse position on scene

        newPosition.x = transform.position.x;    // lock movement on x axis
        newPosition.y = transform.position.y + (mousePosition.y - previousMousePosition.y);
        newPosition.z = transform.position.z;    // lock movement on z axis

        //if ()
        transform.position = newPosition;               // change bumper position

        newPosition.x = controller.transform.position.x;
        newPosition.y = controller.transform.position.y + (mousePosition.y - previousMousePosition.y);
        newPosition.z = controller.transform.position.z;

        controller.transform.position = newPosition;    // change controller position
        previousMousePosition = mousePosition;
    }

    public void resetPosition() {
        transform.position = initialPosition;
        controller.transform.position = initialControllerPosition;
    }
}
