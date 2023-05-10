using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    public Transform player;
    public TMP_Text distText;

    public Rigidbody2D playerBody;
    public PlayerScript2 playerScript;

    float offX;
    public float dist;

    //Get the int distance
    public int prettyDistance
    {
        get { return (int)Math.Truncate(dist); }
    }

    // Start is called before the first frame update
    void Start()
    {
        offX = player.position.x;
        dist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CalculateDistanceTravelled();

        if (distText)
        {
            distText.text = "Dist: " + prettyDistance.ToString() + "m";
        
        }
    }

    void CalculateDistanceTravelled()
    {
        if (!playerScript.health.IsAlive) return;//Calculate distance only if alive

        float x = playerBody.velocity.x;
        if (x > 0)
        {
            dist += x * Time.fixedDeltaTime;
        }
    }

}
