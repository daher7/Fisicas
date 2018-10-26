using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour {

    [SerializeField] GameObject prefabBala;
    [SerializeField] Transform esfera;
    [SerializeField] Transform puntoGeneracion;
    [SerializeField] int fuerza;

    // Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject proyectil = Instantiate(prefabBala, puntoGeneracion.position, puntoGeneracion.rotation);
            proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza);
        }

        float xR = Input.GetAxis("Vertical");
        float yR = Input.GetAxis("Horizontal");
        esfera.Rotate(xR * -1, yR, 0);
	}
}
