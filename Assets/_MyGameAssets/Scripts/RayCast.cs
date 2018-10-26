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

    void Disparar() {
        
        bool hayImpacto = Physics.Raycast(origen.position, origen.forward);
        Debug.DrawRay(origen.position, origen.forward * 100, Color.blue, 50);
        texto.text = "" + hayImpacto;
    }
}
