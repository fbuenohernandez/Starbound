using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller2 : MonoBehaviour
{
    // Pega objeto
    [SerializeField] GameObject projectile;

    // Tempos para loop e delay
    public float updateInterval = 2f;
    private double lastInterval;
    private int frames;
    private float fps;

    // Dispara um laser de tempos em tempos
    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = System.Math.Round(timeNow, 2);

            GameObject fire = Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
