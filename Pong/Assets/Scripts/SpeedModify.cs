using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModify : PowerUp {
    public float multiplier;
    private Rigidbody rb;

    void Start() {
        GameObject ball = GameObject.FindWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    public override void Execute() {
        Debug.Log("Ativou o BOOST");
        ctrlReference.powerUpDisabled = false;
        Debug.Log("Antes Execute==="+rb.velocity);
        rb.velocity = rb.velocity * multiplier;
        Debug.Log("Execute==="+rb.velocity);
    }

    public override void Terminate() {
        rb.velocity = rb.velocity / multiplier;
        Destroy(gameObject);
    }
}