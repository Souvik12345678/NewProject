using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeScript : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + axisX * speed * Time.deltaTime, transform.position.y + axisY * speed * Time.deltaTime);
    }
}
