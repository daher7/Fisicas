using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oveja : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {

        print("VIVA EL TRIGGER: " + gameObject.name);

    }
    
}
