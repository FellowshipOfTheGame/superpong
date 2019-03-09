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
            } else {
                Debug.Log("Não foi possível habilitar Speed Modify! O RigidBody da bolinha é nulo.");
            }
        }
    }

    public override void Terminate() {
        ctrlReference.powerUpDisabled = true;
        if (rb != null) {
            rb.velocity = rb.velocity / multiplier;
            Debug.Log("Terminando speed modify");
            Destroy(gameObject);
        }
    }
}