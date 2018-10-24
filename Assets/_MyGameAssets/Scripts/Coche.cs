using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {

    public float fuerzaMaxMotor = 100;
    public float anguloMaxRotacion = 20;
    public float incrementoFrenado = 10;
    // public float fuerzaMaxFreando = 10;
    private float fuerzaFrenado = 0;
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
       
        if (vPos > 0) {
            // RUEDAS MOTRICES
            SoltarFreno();
            wcBackL.motorTorque = fuerzaMaxMotor * vPos;
            wcBackR.motorTorque = fuerzaMaxMotor * vPos;
        } else if (vPos < 0){
            Frenar();
        } 
             
        // RUEDAS DIRECTRICES
        wcFrontL.steerAngle = anguloMaxRotacion * hPos;
        wcFrontR.steerAngle = anguloMaxRotacion * hPos;
    }

    private void Frenar() {
        fuerzaFrenado = fuerzaFrenado + incrementoFrenado;
        wcFrontL.brakeTorque = fuerzaFrenado;
        wcFrontR.brakeTorque = fuerzaFrenado;
        wcBackL.brakeTorque = fuerzaFrenado;
        wcBackR.brakeTorque = fuerzaFrenado;
    }

    private void SoltarFreno() {
        wcFrontL.brakeTorque = 0;
        wcFrontR.brakeTorque = 0;
        wcBackL.brakeTorque = 0;
        wcBackR.brakeTorque = 0;
    }
}
