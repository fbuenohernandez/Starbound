using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class star_wars_scene_control : MonoBehaviour
{

    // Velocidade do texto se movendo na tela
    public float textSpeed = 0.01f;

    // Objeto do texto de Start game que aparece na tela
    public Text start;
    
    // Objeto do texto que move na tela
    public GameObject starWars;

    // Tempo para ativar o texto de Start
    private float last; 

    void Start()
    {
        // Inicia com o texto de Start game (start) desbilitado
        start.enabled = false;

        // Começa a contar o timeout esconder o texto (starWars)
        last = (float)Math.Round(Time.time);
    }

    void Update()
    {
        // Reseta a velocidade do texto caso solte o botão
        textSpeed = 0.01f;

        // Apertando esc pula a cena
        if (Input.GetKey(KeyCode.Escape))
        {
            skip();
        }

        // Apertando espaco ele dá uma aceleradinha no texto
        if (Input.GetKey(KeyCode.Space))
        {
            fastForward();
        }


        // Se a posição do texto em y por menor que
        if (starWars.transform.position.y < 100f)
        {
            // Move o texto
            starWars.transform.Translate(0, textSpeed, 0);
        }
        else // Caso contrário
        {
            // O texto vai estar parado e depois de um tempo vai sumir
            if ((Math.Round(Time.time) - last) > 1f)
            {
                start.enabled = !start.enabled;
                last = Time.time;
            }

            // Tendo parado o texto (starWars) aparece o start na tela e aí pode apertar enter para começar
            if (Input.GetKey(KeyCode.Return))
            {
                skip();
            }
        }
    }

    public void fastForward() 
    {
        // Aumenta a velocidade do texto (starWars)
        textSpeed += 0.03f;
    }

    public void skip()
    {
        // Muda para a cena seleção de level
        SceneManager.LoadScene("level_selection");
    }
}
