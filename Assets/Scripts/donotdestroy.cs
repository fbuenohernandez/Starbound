using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class donotdestroy : MonoBehaviour
{
    // Pega sons
    GameObject[] bgm;
    GameObject[] move;

    // Start is called before the first frame update
    void Awake()
    {
        // Mantém o som de uma cena para a outra se for a música, se for o som de clique destróy
        bgm = GameObject.FindGameObjectsWithTag("BGM");
        if (bgm.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            bgm[0].GetComponent<AudioSource>().Play();
            Debug.Log("DEU PLAY");
        }

        move = GameObject.FindGameObjectsWithTag("Move");
        if (move.Length == 1) DontDestroyOnLoad(gameObject);

    }
}
