using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche : MonoBehaviour {

    public Text txtFrenoDeMano;
    public Text txtSpeed;
    public Text txtMarcha;
    public float fuerzaMaxMotor = 100f;
    public float anguloMaxRotacion = 20f;
    public float incrementoFrenado = 10f;
    // public float fuerzaMaxFreando = 10;
    private float fuerzaFrenado = 0;
    private float vPos;
    private float hPos;
    bool frenoManoActivo = true;
    // Tenemos que acceder al wheelcollider de cada rueda
    private WheelCollider wcFrontL, wcFrontR, wcBackL, wcBackR;
    float fSpeed; 

    private void Start() {
        wcFrontL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcFrontR = GameObject.Find("FrontR").GetComponent<WheelCollider>();
        wcBackL = GameObject.Find("BackL").GetComponent<WheelCollider>();
        wcBackR = GameObject.Find("BackR").GetComponent<WheelCollider>();

        // PILOTOS ENCENDIDOS
        
    }
    
    void Update()
    {
        // VELOCIDAD
        fSpeed = GetComponent<Rigidbody>().velocity.z;
        txtSpeed.text = ((int)fSpeed).ToString();
        
        if(Input.GetKeyDown(KeyCode.F)){
            frenoManoActivo = !frenoManoActivo;
            // Freno de Mano activo
            if(frenoManoActivo){
                txtFrenoDeMano.text = "Handbrake: ON";
            } else {
                txtFrenoDeMano.text = "Handbrake: OFF";
            }
        }    
    }
    private void FixedUpdate() {

        vPos = Input.GetAxis("Vertical");
        hPos = Input.GetAxis("Horizontal");

        // RUEDAS DIRECTRICES
        wcFrontL.steerAngle = anguloMaxRotacion * hPos;
        wcFrontR.steerAngle = anguloMaxRotacion * hPos;

        if (!frenoManoActivo) {
            if (vPos > 0) {
                txtMarcha.text = "1";
                // RUEDAS MOTRICES
                SoltarFreno();
                wcBackL.motorTorque = fuerzaMaxMotor * vPos;
                wcBackR.motorTorque = fuerzaMaxMotor * vPos;
            } else if (vPos < 0 && fSpeed > 0.01) {
                txtMarcha.text = "0";
                Frenar();
            } else if (vPos < 0 && fSpeed <= 0.01) {
                txtMarcha.text = "R";
                SoltarFreno();
                wcBackL.motorTorque = fuerzaMaxMotor * vPos;
                wcBackR.motorTorque = fuerzaMaxMotor * vPos;
            } 
        } else {
            wcFrontL.brakeTorque = Mathf.Infinity;
            wcFrontR.brakeTorque = Mathf.Infinity;
            wcBackL.brakeTorque = Mathf.Infinity;
            wcBackR.brakeTorque = Mathf.Infinity;
        }       
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
