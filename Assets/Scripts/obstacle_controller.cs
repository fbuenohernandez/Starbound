using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class obstacle_controller: MonoBehaviour
{
    // Variáveis de controle
    Rigidbody rb;
    float speed = 10f;
    BoxCollider bc;

    void Start()
    {
        // Pega os objetos
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Seta velocidade para ir contra player
        rb.velocity = Vector3.down * speed;
    }

    void OnTriggerEnter(Collider other)
    {   
        // Ao chegar ao fim do mapa destrói
        if (other.name == "Bottom") Destroy(this.gameObject);
    }

}
