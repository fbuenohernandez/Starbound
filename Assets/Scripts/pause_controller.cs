using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class pause_controller : MonoBehaviour
{
    // Flag de pausado
    bool paused = false;

    // Serializeds para controlar o fluxo
    [SerializeField]
    AudioSource musica;

    [SerializeField]
    AudioSource ambient;

    [SerializeField]
    GameObject overlay;

    [SerializeField]
    GameObject pause;

    [SerializeField]
    GameObject pauseText;

    [SerializeField]
    GameObject resume;

    [SerializeField]
    GameObject menu;

    [SerializeField]
    GameObject exit;

    [SerializeField]
    GameObject overlay2;

    [SerializeField]
    GameObject menuNo;

    [SerializeField]
    GameObject menuYes;

    [SerializeField]
    GameObject menuSure;

    [SerializeField]
    GameObject overlay3;

    [SerializeField]
    GameObject exitNo;

    [SerializeField]
    GameObject exitYes;

    [SerializeField]
    GameObject exitSure;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    GameObject blackScreen;

    //Objeto do personagem
    [SerializeField]
    GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        // Inicia tudo desativado
        pause.SetActive(false);     
        blackScreen.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Se pressionar esc pausa ou despausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) // Se pausado, retorna o timescale, desativa o sprite de pausado e retoma a música
            {
                Debug.Log("UNPAUSED");

                Time.timeScale = 1f;
                paused = false;
                pause.gameObject.SetActive(false);
                musica.Play();
            }
            else // Se não pausado, para o tempo, para a música e ativa o sprite de pausado
            {
                Debug.Log("PAUSED");
                Time.timeScale = 0f;
                paused = true;
                pause.gameObject.SetActive(true);
                musica.Stop();
            }
        }

        // Se o HP do personagem for 0 para o tempo do jogo, mostra tela preta e game over
        if(ship.GetComponent<character>().getHP() <= 0) 
        {
            Time.timeScale = 0f;
            pause.gameObject.SetActive(true);

            overlay.SetActive(false);
            pauseText.SetActive(false);

            blackScreen.SetActive(true);
            gameOver.SetActive(true);

            resume.SetActive(false);
            
            // A tela preta tem um efeito de que vai aumentando até tomar a tela toda
            blackScreen.transform.localScale = new Vector3(1f, blackScreen.transform.localScale.y + 0.75f, 1f);
        }

        if (Input.GetKey("r"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("level1");
        }

    }

    // Se clicar retoma o jogo pausado
    public void resumeClick()
    {
        Time.timeScale = 1f;
        paused = false;
        pause.gameObject.SetActive(false);
        musica.Play();
    }

    // Se clicar pede para confirmar voltar para o menu
    public void menuClick()
    {
        overlay2.SetActive(true);
        menuNo.SetActive(true);
        menuYes.SetActive(true);
        menuSure.SetActive(true);

        resume.SetActive(false);
        exit.SetActive(false);
    }

    // Caso clique sim no voltar para o menu volta para o menu
    public void menuClickYes()
    {
        SceneManager.LoadScene("home");
    }

    // Caso clique não no voltar para o menu fecha a confirmação
    public void menuClickNo()
    {
        overlay2.SetActive(false);
        menuNo.SetActive(false);
        menuYes.SetActive(false);
        menuSure.SetActive(false);

        resume.SetActive(true);
        exit.SetActive(true);
    }

    // Caso clique em fechar pede confirmação para fechar
    public void exitClick()
    {
        overlay3.SetActive(true);
        exitNo.SetActive(true);
        exitYes.SetActive(true);
        exitSure.SetActive(true);

        resume.SetActive(false);
        menu.SetActive(false);
    }

    // Caso cliqueu sim fecha o jogo
    public void exitClickYes()
    {
        Application.Quit();
    }

    // Caso clique não fecha a confirmação
    public void exitClickNo()
    {
        overlay3.SetActive(false);
        exitNo.SetActive(false);
        exitYes.SetActive(false);

        exitSure.SetActive(false);

        menu.SetActive(true);
        resume.SetActive(true);
        exit.SetActive(true);
    }
    public bool isPaused()
    {
        return paused;
    }

}
