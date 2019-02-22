using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    public float durationTime;
    public GameObject gameController;
    protected GameController ctrlReference;
    // PowerUp icon ?

    void Awake() {
        ctrlReference = gameController.GetComponent<GameController>();
    }

    public abstract void Execute();
    public abstract void Terminate();
}