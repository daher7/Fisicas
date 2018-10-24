using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {

    public float fuerzaMaxMotor = 100;
    public float anguloMaxRotacion = 20;
    private float vPos;
    private float hPos;
    // Tenemos que acceder al wheelcollider de cada rueda
    private WheelCollider wcFrontL, wcFrontR, wcBackL, wcBackR;

    private void Start() {
        wcFrontL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcFrontR = GameObject.Find("FrontR").GetComponent<WheelCollider>();
        wcBackL = GameObject.Find("BackL").GetComponent<WheelCollider>();
        wcBackR = GameObject.Find("BackR").GetComponent<WheelCollider>();

    }

    private void FixedUpdate() {

        vPos = Input.GetAxis("Vertical");
        hPos = Input.GetAxis("Horizontal");
       
        // RUEDAS MOTRICES
        wcBackL.motorTorque = fuerzaMaxMotor * vPos;
        wcBackR.motorTorque = fuerzaMaxMotor * vPos;
        // RUEDAS DIRECTRICES
        wcFrontL.steerAngle = anguloMaxRotacion * hPos;
        wcFrontR.steerAngle = anguloMaxRotacion * hPos;
    }
}
