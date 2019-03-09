using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    public float durationTime;
    public float presenceTime;
    private float timer1;
    private float timer2;
    public GameObject gameController;
    protected GameController ctrlReference;
    protected bool powerUpActive;
    protected Rigidbody rb;

    void Awake() {
        ctrlReference = gameController.GetComponent<GameController>();
        timer1 = 0;
        timer2 = 0;
        powerUpActive = false;
    }

    void Start() {
        gameObject.SetActive(false);
        // INÍCIO ZONA CRÍTICA - o power up não habilita corretamente antes disto
        GameObject ball = GameObject.FindWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
        // FIM ZONA CRÍTICA - o power up agora pode ser executado
        gameObject.SetActive(true);
    }

    void FixedUpdate() {
        DestroyOthers(); // destrua qualquer powerup na cena que não seja este
        if (ctrlReference.powerUpDisabled) {
            timer1 += Time.fixedDeltaTime;
            if (timer1 > presenceTime) {
                Destroy(gameObject);
                timer1 = 0;
            }
        } else {
            timer2 += Time.fixedDeltaTime;
            if (timer2 > durationTime)
                Terminate();
        }
    }

    public abstract void Execute();
    public abstract void Terminate();
    protected void DestroyOthers() {
        GameObject[] instantiatedPowerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (GameObject go in instantiatedPowerUps)
            if (go != gameObject) Destroy(go);
    }
}