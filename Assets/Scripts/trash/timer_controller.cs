using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_controller : MonoBehaviour
{
    public float updateInterval = 0.25f;
    private double lastInterval;
    private int frames;
    private float fps;

    private Text myText;
    float posX = -35;
    float posY = 10;
  
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;

        myText = GetComponent<Text>();

    }


    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = System.Math.Round(timeNow, 2);

            myText.text = lastInterval.ToString();
            myText.transform.position = new Vector2(posX, posY);

        }

    }
}