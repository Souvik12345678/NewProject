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

    float offX;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        offX = player.position.x;
        dist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //dist = player.position.x - offX;
        //if (distText)
        //{
        //    distText.text = "Dist: " + Math.Truncate(dist).ToString() + "u";
        //
        //}
    }

    private void FixedUpdate()
    {
        CalculateDistanceTravelled();

        if (distText)
        {
            distText.text = "Dist: " + Math.Truncate(dist).ToString() + "m";
        
        }
    }

    void CalculateDistanceTravelled()
    {
        float x = playerBody.velocity.x;
        if (x > 0)
        {
            dist += x * Time.fixedDeltaTime;
        }
    }

}
