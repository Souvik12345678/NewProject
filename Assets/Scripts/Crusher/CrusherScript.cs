using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherScript : MonoBehaviour
{
    public Rigidbody2D crusherBody;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        crusherBody.velocity = new Vector2(velocity, crusherBody.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))//If it is a terrain
        {
            Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green);
        }
    }

}
