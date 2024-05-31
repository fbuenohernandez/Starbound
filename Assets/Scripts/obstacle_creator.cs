using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_creator : MonoBehaviour
{
    // Prefab obstáculos
    [SerializeField] GameObject obs1;
    [SerializeField] GameObject obs2;
    [SerializeField] GameObject obs3;
    [SerializeField] GameObject obs4;
    [SerializeField] GameObject obs5;

    // Delimitadores de tela
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] GameObject ypos;

    GameObject obj;

    void Spawn()
    {
        // 1 / 1000 de chance de spawnar
        if (Random.Range(0,1000) == 0)
        {
            // Spawna aleatóriamente um tipo de obstáculos (4 tipos)
            // Spawna aleatóriamente em x dentro da faixa delimitada
            int rand = Random.Range(0, 4);
            Vector3 lane = new Vector3(Random.Range(left.transform.position.x, right.transform.position.x), ypos.transform.position.y, -1);

            switch (rand)
            {
                case 0:

                    obj = Instantiate(obs1, lane, transform.rotation);
                    break;

                case 1:

                    obj = Instantiate(obs2, lane, transform.rotation);
                    break;

                case 2:

                    obj = Instantiate(obs3, lane, transform.rotation);
                    break;

                case 3:

                    obj = Instantiate(obs4, lane, transform.rotation);
                    break;

                case 4:

                    obj = Instantiate(obs4, lane, transform.rotation);
                    break;
            }
        }
    }

    void Update()
    {
        // Spawna inimigos
        Spawn();
    }
}
