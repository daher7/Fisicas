using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    [SerializeField] Transform target;
    Rigidbody miRigidBody;

    private void Start() {
        miRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 distancia = target.position - transform.position;
        // Lo convertimos en distancia de 1 unidad
        Vector3 distanciaNormalizada = distancia.normalized;

        Vector3 deltaPostion = distanciaNormalizada * Time.deltaTime;
        if(distancia.magnitude > 0.1f) {
            // Para que cuando llegue a la esfera no de saltitos
            miRigidBody.MovePosition(miRigidBody.position + deltaPostion);
        }
       
    }

}
