using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class howto_animation1 : MonoBehaviour
{
    // Controle da movimentação
    float speed = 2f; // Velocidade do movimento
    float radius = 0.5f; // Radio do movimento
    float angle = 0f; // Angulo atual
    float xx = - 4;
    float yy = 1;

    private Rigidbody rb;

    void Start()
    {
        // Pega objeto
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimenta o sprite em um círculo
        angle += -speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius + xx;
        float y = Mathf.Sin(angle) * radius * 0.5f + yy;

        rb.MovePosition(new Vector3(x, y, 0));

    }
}
