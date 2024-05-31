using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class enemy_controller: MonoBehaviour
{
    // Objetos e controles
    Rigidbody rb;
    public float speed = 1000f;
    BoxCollider bc;

    //// Mixer
    //public AudioSource explosion;

    void Start()
    {
        // Pega objetos
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Seta força para o inimigo para baixo
        rb.AddForce(0, speed, 0, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Caso chegue no fundo destrói
        if (collision.collider.tag == "Bottom") Destroy(this.gameObject);

        // Caso encoste no player tira vida dele e destroi e toca som
        if (collision.transform.GetComponent<character>())
        {
            //explosion.Play();
            collision.transform.GetComponent<character>().playExplosion();
            collision.transform.GetComponent<character>().takeDamage();
            Destroy(this.gameObject);
        }

        // Caso colida com o laser destrói e toca som
        if (collision.collider.name.Contains("Laser"))
        {
            //explosion.Play();
            GameObject.Find("Ship").GetComponent<character>().playExplosion();
            Destroy(this.gameObject);
            GameObject.Find("Ship").GetComponent<character>().addPoints();
        }

    }
}
