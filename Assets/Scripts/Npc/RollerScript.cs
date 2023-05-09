using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerScript : MonoBehaviour
{
    public float maxTorq;
    public float maxAngVel;

    public Rigidbody2D body;
    public Transform target;
    public AudioSource audSrc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(body.angularVelocity);
    }

    private void FixedUpdate()
    {
        if (body.angularVelocity < maxAngVel)
        {
            body.AddTorque(maxTorq);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("crusher"))
        {
            audSrc.Play();
            Destroy(gameObject);
        }
    }

}
