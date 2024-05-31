using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy_creator : MonoBehaviour
{
    // Pega objetos
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    GameObject enemy;

    // Delimitação da fase
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] GameObject ypos;

    // Timeout 
    public float delay = 10f;
    float lastTime = 0f;

    // Spawna inimigos com diferentes formações em lugares diferentes na pista
    void SpawnV(GameObject obj, int formation, float translate)
    {
        // Se deu o timeout
        if ((Time.time - lastTime) > delay)
        {
            int type = 1;
            
            // Instancia formação
            switch (formation)
            {
                case 0: // Formação 0 0 1 0 0

                    obj = Instantiate(obj, new UnityEngine.Vector3(0 + translate, ypos.transform.position.y, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));
                    break;


                case 1: // Formação 0 1 0 1 0

                    obj = Instantiate(obj, new UnityEngine.Vector3(-2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;


                case 2:  // Formação 0 1 1 1 0

                    obj = Instantiate(obj, new UnityEngine.Vector3(0 + translate, ypos.transform.position.y, 0),
           transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(-2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;


                case 3: // Formação 1 0 0 0 1

                    obj = Instantiate(obj, new UnityEngine.Vector3(-5 + translate, ypos.transform.position.y + 5 * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(5 + translate, ypos.transform.position.y + 5 * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;


                case 4:  // Formação 1 0 1 0 1

                    obj = Instantiate(obj, new UnityEngine.Vector3(0 + translate, ypos.transform.position.y, 0),
          transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(-5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;


                case 5: // Formação 1 1 0 1 1

                    obj = Instantiate(obj, new UnityEngine.Vector3(-5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(-2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;


                case 6: // Formação 1 1 1 1 1

                    obj = Instantiate(obj, new UnityEngine.Vector3(0 + translate, ypos.transform.position.y, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(-5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(-2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    obj = Instantiate(obj, new UnityEngine.Vector3(2.5f + translate, ypos.transform.position.y + 2.5f * type, 0),
                transform.rotation * UnityEngine.Quaternion.Euler(0f, 0f, 180f));

                    break;

            }

            lastTime = Time.time;
        }
    }

    void Spawn()
    {
        // Seleciona inimigo aleatório
        int enemy_ = Random.Range(0, 2);

        switch (enemy_)
        {
            case 0:
                enemy = enemy1;
                break;

            case 1:
                enemy = enemy2;
                break;

            case 2:
                enemy = enemy3;
                break;
        }

        int formation = Random.Range(1, 6);
        float translate = Random.Range(-5, 5);

        //Debug.Log("ENEMY " + enemy_ + " FORMATION " + formation);

        SpawnV(enemy, formation, translate);
        
    }

    void Update()
    {
        Spawn();
    }
}
