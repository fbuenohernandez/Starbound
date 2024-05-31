using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class home_screen_control : MonoBehaviour
{
    // Textos da tela inicial
    public Text newGame;
    public Text howto;
    public Text options;
    public Text credits;
    public Text exit;
    public CanvasRenderer cursor;

    // Áudio
    public AudioSource move;

    // Seleção atual
    private int currentSelection = 0;

    // Tamanho dos textos 0.4f quando em destaque e 0.2 quando não
    public float minSize = 0.2f;
    public float maxSize = 0.4f;

    GameObject[] bgm;

    enum menuEnum
    {
        home = 0,
        howto = 1,
        options = 2,
        credits = 3,
        exit = 4
    }

    void Start()
    {
        // Inicia com new game no tamanho correto
        newGame.color = new Color(0, 1, 0);
        howto.color = new Color(0, 0.5f, 0);
        options.color = new Color(0, 0.5f, 0);
        credits.color = new Color(0, 0.5f, 0);
        exit.color = new Color(0, 0.5f, 0);

        // Seta resolução default           
        Screen.SetResolution(1920, 1080, true);
        move = GameObject.Find("Move").GetComponent<AudioSource>();
    }

    void toggleColor(int n)
    {
        // Reseta todas as cores para greyed out
        menuEnum menu = (menuEnum)n;
        newGame.color = new Color(0, 0.5f, 0);
        howto.color = new Color(0, 0.5f, 0);
        options.color = new Color(0, 0.5f, 0);
        credits.color = new Color(0, 0.5f, 0);
        exit.color = new Color(0, 0.5f, 0);

        // Reseta todos os textos para o tamanho mínimo
        newGame.transform.localScale = Vector3.one * minSize;
        howto.transform.localScale = Vector3.one * minSize;
        options.transform.localScale = Vector3.one * minSize;
        credits.transform.localScale = Vector3.one * minSize;
        exit.transform.localScale = Vector3.one * minSize;


        // Alterna qual texto está em evidência e move o cursor (navezinha) para o y do texto
        switch (menu)
        {
            case menuEnum.home:
                newGame.color = Color.green;
                newGame.transform.localScale = Vector3.one * maxSize;
                cursor.GetComponent<Rigidbody2D>().transform.position = new Vector2(cursor.GetComponent<Rigidbody2D>().transform.position.x, newGame.transform.position.y);

                break;
            case menuEnum.howto:
                howto.color = Color.green;
                howto.transform.localScale = Vector3.one * maxSize;
                cursor.GetComponent<Rigidbody2D>().transform.position = new Vector2(cursor.GetComponent<Rigidbody2D>().transform.position.x, howto.transform.position.y);

                break;
            case menuEnum.options:
                options.color = Color.green;
                options.transform.localScale = Vector3.one * maxSize;
                cursor.GetComponent<Rigidbody2D>().transform.position = new Vector2(cursor.GetComponent<Rigidbody2D>().transform.position.x, options.transform.position.y);

                break;
            case menuEnum.credits:
                credits.color = Color.green;
                credits.transform.localScale = Vector3.one * maxSize;
                cursor.GetComponent<Rigidbody2D>().transform.position = new Vector2(cursor.GetComponent<Rigidbody2D>().transform.position.x, credits.transform.position.y);

                break;
            case menuEnum.exit:
                exit.color = Color.green;
                exit.transform.localScale = Vector3.one * maxSize;
                cursor.GetComponent<Rigidbody2D>().transform.position = new Vector2(cursor.GetComponent<Rigidbody2D>().transform.position.x, exit.transform.position.y);

                break;
        }
    }

    void toggleScene(int n)
    {
        // Alterna entre as cenas, se for new game destrói a bgm
        switch (n)
        {
            case 0:
                bgm = GameObject.FindGameObjectsWithTag("BGM");
                Destroy(bgm[0]);
                SceneManager.LoadScene("newgame");
                break;
            case 1:
                SceneManager.LoadScene("howto");
                break;
            case 2:
                SceneManager.LoadScene("options");
                break;
            case 3:
                SceneManager.LoadScene("credits");
                break;
            case 4:
                Application.Quit();
                break;
        }
    }
   
     void Update()
    {

        int selected = currentSelection;

        // Alterna entre as seleções
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            selected = Math.Max(selected - 1, 0);
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            selected = Math.Min(selected + 1, 4);
        }

        // Se a seleção atual for diferente da anterior toca som (só toca se mudou)
        if (selected != currentSelection) move.Play();

        // Passa de uma variável para outra (não precisava né)
        currentSelection = selected;

        // Seleciona a cena
        toggleColor(currentSelection);

        // Quando selecionado toca som
        if (Input.GetKeyDown(KeyCode.Return))
        {            
            move.Play();
            toggleScene(currentSelection);
        }
    }
}
