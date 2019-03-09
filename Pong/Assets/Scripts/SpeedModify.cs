using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModify : PowerUp {
    public float multiplier;

    public override void Execute() {
        if (ctrlReference.powerUpDisabled) {
            Debug.Log("Executando speed modify");
            ctrlReference.powerUpDisabled = false;
            if (rb != null) {
                rb.velocity = rb.velocity * multiplier;
                Debug.Log("ativou");
                powerUpActive = true;
            }
        }
    }

    public override void Terminate() {
        if (rb != null) {
            ctrlReference.powerUpDisabled = true;
            if (powerUpActive) {
                rb.velocity = rb.velocity / multiplier;
                Debug.Log("Terminando speed modify");
                powerUpActive = false;
            }
            Destroy(gameObject);
        }
    }
}