using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class credits_screen_control : MonoBehaviour
{
    public AudioSource move;

    // Volta para o home, est� sendo usando por how to play tamb�m
    public void homeClick()
    {
        move.Play();
        SceneManager.LoadScene("home");
    }

}
