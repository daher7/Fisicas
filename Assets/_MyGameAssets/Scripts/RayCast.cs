using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour {

    public Transform origen;
    public Transform destino;
    public Text texto;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Disparar();
        }
	}
    // Dos Métodos para usar los RayCast
    // RayCastAll
    /*
    public void Disparar() {
        RaycastHit[] rhs = Physics.RaycastAll(
            origen.position,
            origen.forward);
        // Ha colisionado con algo
        if (rhs.Length != 0) {
            // Recorremos el array para saber el nombre de cada objeto con el que ha impactado
            for( int i = 0; i < rhs.Length; i++) {
                print(rhs[i].transform.gameObject.name);
            }
        }
    }
    */
    
    private void Disparar() {
        RaycastHit rh;
        // bool hayImpacto = Physics.Raycast(origen.position, origen.forward);
        bool hayImpacto = Physics.Raycast(
            origen.position,
            origen.forward,
            out rh);

        // Debug.DrawRay(origen.position, origen.forward * 100, Color.blue, 50);
        texto.text = "" + hayImpacto;
        if (hayImpacto) {
            string nombreObjetoImpactado = rh.transform.gameObject.name;
            texto.text = nombreObjetoImpactado;
        }     
    }
    
}
