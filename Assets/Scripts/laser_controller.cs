using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class laser_controller : MonoBehaviour
{
    // Objetos e variáveis
    Rigidbody rb;
    public float energy = 10f;
    [SerializeField] GameObject barrier;
    
    void Start()
    {
        // Pega o rigid body
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move o laser para frente e destroy o objeto ao sair da tela
        rb.AddForce(0, energy, 0, ForceMode.Impulse);
        if (this.transform.position.y > barrier.transform.position.y) Destroy(this.gameObject);
    }

    // Se o colisor tem "nem" no nome ou alcançou o topo destroy
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name.Contains("nemy")) Destroy(this.gameObject);
        if (collision.collider.name.Contains("Top")) Destroy(this.gameObject);

    }
}
