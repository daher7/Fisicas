using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaOveja : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {

        // Esto no se ejecuta porque en la jerarquia hay un padre con RigidBody 
        print("CABEZA OVEJA TRIGGER: " + gameObject.name);
    }
}
