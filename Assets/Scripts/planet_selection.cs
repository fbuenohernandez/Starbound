using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_selection : MonoBehaviour
{
    private int currentSelection = 0;
   
    // Outlines de seleção dos planetas
    SpriteRenderer iceOutline;
    SpriteRenderer magmaOutline;
    SpriteRenderer blackOutline;

    // Sons do jogo
    public AudioSource selectMove;
    public AudioSource selectError;
    public AudioSource selectCorrect;

    // Alterna seleção 
    void toggleSelection()
    {
        // Começa tudo desativado
        iceOutline.enabled = false;
        magmaOutline.enabled = false;   
        blackOutline.enabled = false;

        // Ativa de acordo com o input que recebe
        switch (currentSelection)
        {
            case 0:
                iceOutline.enabled = true;               
                break;
            case 1:
                magmaOutline.enabled = true;               
                break;
            case 2:
                blackOutline.enabled = true;
                break;
        }
    }

    // Inicia a cena desejada, no caso só fiz do primeiro planeta, os outros vão sair na DLC
    void toggleScene(int n)
    {
        switch (n)
        {
            case 0:
                SceneManager.LoadScene("level1");
                break;
        }
    }


    void Start()
    {
        // Pega os objetos dos respectivos planetas
        iceOutline = GameObject.Find("selection_ice").GetComponent<SpriteRenderer>();
        magmaOutline = GameObject.Find("selection_magma").GetComponent<SpriteRenderer>();
        blackOutline = GameObject.Find("selection_black").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        // Alterna/move a seleção e toca um som
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            currentSelection = System.Math.Max(currentSelection - 1, 0);
            selectMove.Play();
        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            currentSelection = System.Math.Min(currentSelection + 1, 2);
            selectMove.Play();
        }

        toggleSelection();


        // Caso selecionou o planeta possível de jogar toca um som de seleção, para o som ser tocado inteiro há um delay antes de mudar de cena
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentSelection == 0)
            {
                selectCorrect .Play();

                float delay = 5000;

                while (delay-- > 0) {;}

                toggleScene(currentSelection);
            } // Caso o planeta saia na DLC toca um som e erro
            else selectError.Play();

            Debug.Log(currentSelection);
        }

    }
}
