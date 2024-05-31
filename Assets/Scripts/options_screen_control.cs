using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class options_screen_control : MonoBehaviour
{
    // Objetos de controle
    public Slider volume;
    public Dropdown resolution;
    public Toggle full;

    // Cria arrays com resoluções
    static int[] option1 = new int[2] { 800, 600 };
    static int[] option2 = new int[2] { 1024, 768};
    static int[] option3 = new int[2] { 1920, 1080};

    // Variáveis de controle
    int w, h;
    bool fullS = true;

    // Cria array de arrays para setar as resoluções
    int[][] resolutions = new int[][] { option1, option2, option3 };

    // Objeto do mixer e áudio de seleção
    public AudioMixer master;
    public AudioSource move;


    void Start()
    {
        // Pega referência dos objetos
        volume = GameObject.Find("Canvas").GetComponentInChildren<UnityEngine.UI.Slider>();
        resolution = GameObject.Find("Canvas").GetComponentInChildren<Dropdown>();
        full = GameObject.Find("Canvas").GetComponentInChildren<Toggle>();
    }

    // Ao mexer o slider do volume muda o volume
    public void sliderChange()
    {
        Debug.Log(volume.value);

        float vol = 40f;

        vol = volume.value > 0.01 ? vol * volume.value - 40f : -80f;

        master.SetFloat("Volume", vol);

    }

    // Ao mexer na resolução seta a nova resolução
    public void resolutionChange()
    {

        w = resolutions[resolution.value][0];
        h = resolutions[resolution.value][1];


        Screen.SetResolution(w, h, fullS);
        Debug.Log(resolution.value + " " + w + " " + h);
    }

    // Ao setar/resetar o toogle muda para fullscreen ou tira
    public void togglerChange()
    {
        Debug.Log(full.isOn);
        fullS = !fullS;
        Screen.SetResolution(w, h, fullS);
    }

    // Caso clique volta para o home
    public void homeClick()
    {
        move.Play();
        SceneManager.LoadScene("home");
    }

}
