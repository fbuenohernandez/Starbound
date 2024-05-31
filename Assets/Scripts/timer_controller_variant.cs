using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_controller_variant : MonoBehaviour
{
    // Taxa de atualiza��o
    public float updateInterval = 0.25f;

    // O valor de tempo obtido do �ltimo refresh
    private double lastInterval;

    // Texto do tempo na tela
    private Text myText;
      
    void Start()
    {
        // Primeiro valor de tempo ao come�ar
        lastInterval = Time.realtimeSinceStartup;

        // Pega a componente do texto
        myText = GetComponent<Text>();
    }


    void Update()
    {
        // Tempo atual
        float timeNow = Time.realtimeSinceStartup;

        // Se o tempo atual passou o intervalo de update
        if (timeNow > lastInterval + updateInterval)
        { 
            // Pega o tempo e arredonda 
            lastInterval = System.Math.Round(timeNow, 2);

            // Escreve na tela
            myText.text = lastInterval.ToString();
        }

    }
}