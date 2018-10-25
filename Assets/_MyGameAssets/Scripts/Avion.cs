﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : MonoBehaviour {

    public int speed = 100;

    // Update is called once per frame


	void Update () {
        float vPos = Input.GetAxis("Vertical");
        float hPos = Input.GetAxis("Horizontal");

        // AVANZAR SIN PULSAR NADA
        GetComponent<CharacterController>().Move(
            transform.forward * Time.deltaTime * speed);

        // ROTAMOS EL AVION HACIA ARRIBA Y HACIA ABAJO
        transform.Rotate(new Vector3(1 * vPos, 0, 0));

        // GIRAMOS EL AVION
        transform.Rotate(new Vector3(vPos, hPos*-1, hPos*-1));

        /*
         * PARA UN OBJETO TERRESTRE
        GetComponent<CharacterController>().SimpleMove(
            Vector3.forward * 
            Time.deltaTime * 
            speed);
        */
	}
}
