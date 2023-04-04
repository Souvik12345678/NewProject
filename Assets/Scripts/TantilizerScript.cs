using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?
/// </summary>
public class TantilizerScript : MonoBehaviour
{
    public Transform bait;
    public float baitBias;

    public int forward = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            forward = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            forward = -1;
        }
        else 
        {
            forward = 0;
        }

        var pos = transform.position;
        pos.x = pos.x + (baitBias * forward);

        bait.transform.position = pos;

    }
}
