using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    // Váriaveis do personagem
    public int playerHP = 3;
    public float shipCurrentSpeed;
    public float shipNormalSpeed = 15f;
    public float shipSlowSpeed = 5f;
    public float distance = 1f;
    public float distanceTop = 60f;

    // Variáveis do raycast
    public float d = 5000;
    RaycastHit hitInfoL;
    RaycastHit hitInfoR;
    RaycastHit hitInfoU;
    RaycastHit hitInfoD;

    // Delay para o tiro
    public float delay = 0.2f;
    float lastShot = 0f;

    // Tempo que o a nuvem influencia a velocidade
    public float cloudDelay = 1f;
    public float cloudTime = 0;

    // Pega objeto
    [SerializeField] GameObject projectile;

    public AudioSource myaudio;

    // Gameobject da vida
    [SerializeField] GameObject L1;
    [SerializeField] GameObject L2;
    [SerializeField] GameObject L3;

    // Pontuação máxima e atual
    public int score;
    public int maxScore;

    // Texto dos scores
    [SerializeField] Text scoreText;
    [SerializeField] Text maxScoreText;

    // Mixer
    public AudioSource explosion;

    // Gameobject fogo
    public GameObject fogo;

    // Gameobject particles laser
    public ParticleSystem laserfire;

    // Toca som explosão
    public void playExplosion()
    {
        explosion.Play();
    }

    // Soma ponto para inimigo morto
    public void addPoints()
    {
        score += 10;
    }
   
    // Tira dano do player
    public void takeDamage()
    {
        playerHP -= 1;
    }

    // Pega o HP atual do player
    public int getHP()
    {
        return playerHP;
    }

    // Salva score no PC
    public void saveScore()
    {
        PlayerPrefs.SetInt("Max", score);
        PlayerPrefs.Save();
    }

    // Carrega score
    public void loadScore()
    {
        maxScore = PlayerPrefs.GetInt("Max", 0);
        maxScoreText.text = "Max score: " + maxScore;
    }

    private void Start()
    {
        // Carrega a pontuação máxima última
        loadScore();
        fogo = GameObject.Find("fogo");
    }

    void checkRay()
    {

        if (Physics.Raycast(transform.position,Vector3.left,out hitInfoL,d))
        {
            //Debug.Log("LEFT " + hitInfoL.distance);
        }

        if (Physics.Raycast(transform.position,Vector3.right,out hitInfoR,d))
        {
            //Debug.Log("RIGHT " + hitInfoR.distance);
        }

        if (Physics.Raycast(transform.position,Vector3.up,out hitInfoU,d))
        {
            //Debug.Log("UP " + hitInfoU.distance);
        }

        if (Physics.Raycast(transform.position,Vector3.down,out hitInfoD,d))
        {
            //Debug.Log("DOWN " + hitInfoD.distance);
            //Debug.Log(hitInfoD.distance + " " + distanceBottom);
        }

    }


void Update()
    {
        // Se o score atual é mais que o máx, substitue máx 
        scoreText.text = "Score: " + score;

        if (maxScore < score)
        {
            maxScore = score;
            maxScoreText.text = "Max score: " + maxScore;
            saveScore();
        }

        // Tempo que a nuvem influencia o personagem
        if(((Time.time - cloudTime) > cloudDelay) && (shipCurrentSpeed != shipNormalSpeed))
        {
            shipCurrentSpeed = shipNormalSpeed;
            cloudTime = Time.time;
        }

        // Desenha raycast
        checkRay();

        // Move personagem
        if ((Input.GetKey("a") || Input.GetKey("left")) && hitInfoL.distance > distance)
        {
            this.transform.Translate(Vector3.left * shipCurrentSpeed * Time.deltaTime);
        }
        else if ((Input.GetKey("d") || Input.GetKey("right")) && hitInfoR.distance > distance)
        {
            this.transform.Translate(Vector3.right * shipCurrentSpeed * Time.deltaTime);
        }

        if ((Input.GetKey("w") || Input.GetKey("up")) && hitInfoU.distance > distanceTop)
        {
            this.transform.Translate(Vector3.up * shipCurrentSpeed * Time.deltaTime);
        }
        else if ((Input.GetKey("s") || Input.GetKey("down")) && hitInfoD.distance > distance)
        {
            this.transform.Translate(Vector3.down * shipCurrentSpeed * Time.deltaTime);
        }

        // if (Input.GetKey("r")) this.transform.position = new Vector3(0, 3.9f, -1);


        // Se já deu tempo do último laser pode atirar de novo (instancia, toca som e anota tempo)
        if ((Input.GetKey("space") || Input.GetMouseButtonDown(0)) && (Time.time - lastShot) > delay && !GameObject.Find("PauseControl").GetComponent<pause_controller>().isPaused())
        {
            GameObject fire = Instantiate(projectile, transform.position, transform.rotation);
            myaudio.Play();
            lastShot = Time.time;

            Instantiate(laserfire, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 0));
        }

        // Mostra os corações do HP, se for == 1 mostra fumaça (partículas)
        switch (playerHP)
        {
            case 0:
                Debug.Log("MORREU");
                L1.SetActive(false);
                L2.SetActive(false);
                L3.SetActive(false);
                break;
            case 1:
                L1.SetActive(true);
                L2.SetActive(false);
                L3.SetActive(false);
                fogo.SetActive(true);
                break;
            case 2:
                L1.SetActive(true);
                L2.SetActive(true);
                L3.SetActive(false);
                fogo.SetActive(false);
                break;
            case 3:
                L1.SetActive(true);
                L2.SetActive(true);
                L3.SetActive(true);
                fogo.SetActive(false);
                break;
        }
    }


    // Desenha raycast
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.left * 1000);
        Gizmos.DrawRay(transform.position, Vector3.right * 1000);
        Gizmos.DrawRay(transform.position, Vector3.up * 1000);
        Gizmos.DrawRay(transform.position, Vector3.down * 1000);
    }

    // Se trigger nuvem seta flag
    private void OnTriggerEnter(Collider other)
    {
        shipCurrentSpeed = shipSlowSpeed;
        cloudTime = Time.time;
    }

}
